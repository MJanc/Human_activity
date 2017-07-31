
/* Includes ------------------------------------------------------------------*/
#include "stm32f4xx.h"
#include "stm32f4xx_it.h"
#include "added_func.h"
#include "config.h"
#include <misc.h>
#include <stm32f4xx_usart.h>
#include <stdio.h>
#include "stm32f429i_discovery.h"
#include "stm32f429i_discovery_lcd.h"
#include "stm32f429i_discovery_ioe.h"


static void TP_Config(void);



#define MAX_STRLEN 12 // this is the maximum string length of our string in characters
#define SIGNAL_PERCENTAGE 80
#define NUMBER_OF_SAMPLES 1000
#define FILTER 2
#define PI 3.1415927

volatile char received_string[MAX_STRLEN+1]; // this will hold the recieved string

TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
TIM_OCInitTypeDef  TIM_OCInitStructure;
__IO uint16_t CCR1_Val = 65535;		//40000
static uint16_t PrescalerValue = 0;
//////////////////////ADC///////////////////
__IO uint16_t uhADCxConvertedValue = 0;
__IO uint32_t uwADCxConvertedVoltage = 0;

uint32_t ConvertedVoltage = 0;

int measHours = 0, measMinutes = 0, measSeconds = 0, measMiliseconds = 0, measMs = 0;

int sampleNumber = 0;

volatile int samples[NUMBER_OF_SAMPLES];
volatile int lastsamples[NUMBER_OF_SAMPLES];
int period [4];
double averPeriod;
double BPM;
int HRV;
int lastSample, lastSample2;
int sampleMs, lastSampleMs;

int sampleNow;

int max[5][2];
int samplesMax;
int samplesMin;
int voltageRange;
int filterSample;

char resultBPM[5];
char resultHRV[5];

char resultBPMShow[9];
char resultHRVShow[9];



double Ts = 1.0/200.0;
double fg = 0.25;
double RC = 1.0;
double c[FILTER + 1] = { 1.0, 1.0, 1.0 };
double d[FILTER + 1] = { 1.0, 1.0, 1.0 };
double x[FILTER + 1];
double y[FILTER + 1];



int arrayX=0, arrayY=0;
int count = 0;

////////////////////////////////////////////
void Delay(__IO uint32_t nCount) {
  while(nCount--) {
  }
}
//////////////////////////////////////////////////////////////////////////

void Calculate()
{
	static int i = 0;

	samplesMax = 0;
	samplesMin = 3300;
	for(i=1;i<NUMBER_OF_SAMPLES;i++)
	{
		if(samples[i] > samples[i-1] && samples[i] > samplesMax)
			samplesMax = samples[i];
		if(samples[i] < samples[i-1] && samples[i] < samplesMin)
			samplesMin = samples[i];
	}

	voltageRange = samplesMax - samplesMin;

	i = 1;
	while(!(samples[i]>=(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin) &&
			samples[i-1]<(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin)))
	{
		max[0][0] = samples[i];
		max[0][1] = i;
		i++;
	}

	i+=10;
	while(!(samples[i]>=(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin) &&
			samples[i-1]<(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin)))
	{
		max[1][0] = samples[i];
		max[1][1] = i;
		i++;
	}
	i+=10;
	while(!(samples[i]>=(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin) &&
			samples[i-1]<(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin)))
	{
		max[2][0] = samples[i];
		max[2][1] = i;
		i++;
	}
	i+=10;
	while(!(samples[i]>=(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin) &&
			samples[i-1]<(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin)))
	{
		max[3][0] = samples[i];
		max[3][1] = i;
		i++;
	}
	i+=10;
	while(!(samples[i]>=(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin) &&
			samples[i-1]<(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin)))
	{
		max[4][0] = samples[i];
		max[4][1] = i;
		i++;
	}


	period[3] = (max[4][1] - max[3][1]);
	period[2] = (max[3][1] - max[2][1]);
	period[1] = (max[2][1] - max[1][1]);
	period[0] = (max[1][1] - max[0][1]);

	averPeriod = ((period[3] + period[2] + period[1] + period[0]) / 4.0 )*0.005;

	BPM = (1.0/averPeriod)*60.0;



}



void calculateFilter()
{
	RC = sqrt(sqrt(2.0)-1.0)/(2.0*PI*fg);
	c[0] = Ts*Ts;
	c[1] = 2*(Ts*Ts);
	c[2] = Ts*Ts;
	d[0] = Ts*Ts+4*RC*Ts+4*(RC*RC);
	d[1] = 2*(Ts*Ts)-8*(RC*RC);
	d[2] = Ts*Ts+4*(RC*RC)-4*RC*Ts;



}

void TIM_Config(void);


int main(void)
{
	LCD_Init();
	LCD_LayerInit();
	LTDC_Cmd(ENABLE);
	LCD_SetLayer(LCD_FOREGROUND_LAYER);

	TP_Config();



	TIM_Config();
	PrescalerValue = (uint16_t) ((SystemCoreClock / 2) / 6000000) - 1;
	TIM_TimeBaseStructure.TIM_Period = 30000 - 1;
	TIM_TimeBaseStructure.TIM_Prescaler = 0;
	TIM_TimeBaseStructure.TIM_ClockDivision = 0;
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;

	TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);
	TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);

	TIM_SelectOutputTrigger(TIM3, TIM_TRGOSource_Update);



	TIM_PrescalerConfig(TIM3, PrescalerValue, TIM_PSCReloadMode_Immediate);

	init_UART5(115200);
	TIM_Cmd(TIM3, ENABLE);
	ADC_Config();
	ADC_SoftwareStartConv(ADC3);

	LCD_SetColors(LCD_COLOR_BLUE, LCD_COLOR_WHITE);


	resultBPMShow[0] = 'B';
	resultBPMShow[1] = 'P';
	resultBPMShow[2] = 'M';
	resultBPMShow[3] = ' ';
	resultBPMShow[8] = NULL;

	resultHRVShow[0] = 'H';
	resultHRVShow[1] = 'R';
	resultHRVShow[2] = 'V';
	resultHRVShow[3] = ' ';
	resultHRVShow[8] = NULL;

	calculateFilter();


	while (1){

		LCD_SetColors(LCD_COLOR_BLUE, LCD_COLOR_WHITE);

		for(count = 3; count < 915; count=count+3)
		{
			lastsamples[count] = samples[count];
			arrayY = (int)(samples[count] / 14.0);
			LCD_DrawFullCircle(arrayY, (int)(count/3), 1);

		}


		ConvertBPM();
		ConvertHRV();

		resultBPMShow[4] = resultBPM[0];
		resultBPMShow[5] = resultBPM[1];
		resultBPMShow[6] = resultBPM[2];
		resultBPMShow[7] = resultBPM[3];

		resultHRVShow[4] = resultHRV[0];
		resultHRVShow[5] = resultHRV[1];
		resultHRVShow[6] = resultHRV[2];
		resultHRVShow[7] = resultHRV[3];

		LCD_DisplayStringLine(LINE(37), (uint8_t*)(resultBPMShow));

		LCD_DisplayStringLine(LINE(39), (uint8_t*)(resultHRVShow));


		LCD_SetColors(LCD_COLOR_WHITE, LCD_COLOR_WHITE);
		for(count = 3; count < 915; count=count+3)
		{
			arrayY = (int)(lastsamples[count] / 14.0);
			LCD_DrawFullCircle(arrayY, (int)(count/3), 1);

		}
	}

}





void DMA2_Stream0_IRQHandler(void)
{



 if(DMA_GetITStatus(DMA2_Stream0, DMA_IT_TCIF0))
 {




	  uhADCxConvertedValue = ADC3->DR;
	  uwADCxConvertedVoltage = (uhADCxConvertedValue *3300/0xFFF);
	  samples[sampleNumber] = (int)uwADCxConvertedVoltage;
	  sampleNumber++;
	  sampleNow = (int)uwADCxConvertedVoltage;

	  if(sampleNumber >= NUMBER_OF_SAMPLES)
	  {
		  sampleNumber = 0;
		  Calculate();
	  }

	  if((int)uwADCxConvertedVoltage>=(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin) &&
				lastSample<(int)(SIGNAL_PERCENTAGE*(voltageRange/100.0) + samplesMin))
	  {
		  sampleMs = measMs;
		  if(lastSampleMs > sampleMs)
		  {
			  HRV = (sampleMs + (9999-lastSampleMs));
		  }
		  else
		  {
			  HRV = (sampleMs - lastSampleMs);
		  }

	  }


	  x[0] = (double)((int)sampleNow);
	  y[0] = (x[0]*c[0]+x[1]*c[1]+x[2]*c[2]-y[1]*d[1]-y[2]*d[2])/(d[0]);

	  x[2] = x[1];
	  y[2] = y[1];
	  x[1] = x[0];
	  y[1] = y[0];

	  filterSample = (int) y[0];


	  Send(uwADCxConvertedVoltage);
	  SendMeasTime();
	  Send(((int)(BPM)));
	  Send(HRV);
	  SendEnd(filterSample);

	  lastSample2 = lastSample;
	  lastSample = (int)uwADCxConvertedVoltage;
	  lastSampleMs = sampleMs;

	  DMA_ClearITPendingBit(DMA2_Stream0, DMA_IT_TCIF0);
  }
 }
static void TP_Config(void)
{

  LCD_Clear(LCD_COLOR_WHITE);


  if (IOE_Config() == IOE_OK)
  {
    LCD_SetFont(&Font8x8);
  }
  else
  {
    LCD_Clear(LCD_COLOR_RED);
    LCD_SetTextColor(LCD_COLOR_BLACK);
    LCD_DisplayStringLine(LCD_LINE_6,(uint8_t*)"   IOE NOT OK      ");
    LCD_DisplayStringLine(LCD_LINE_7,(uint8_t*)"Reset the board   ");
    LCD_DisplayStringLine(LCD_LINE_8,(uint8_t*)"and try again     ");
  }
}





#ifdef  USE_FULL_ASSERT


void assert_failed(uint8_t* file, uint32_t line)
{

  while (1)
  {}
}
#endif


