
#include "added_func.h"


void USART_puts(USART_TypeDef* USARTx, volatile char *s){

	while(*s){
		// wait until data register is empty
		while( !(USARTx->SR & 0x00000040) );
		USART_SendData(USARTx, *s);
		*s++;
	}
}

void Send(int send)
{

	  static char result[5];

	  if (send < 1000)
		  result [0] = '0';
	  else
		  result [0] = (char)(send/1000) + 48;		//tysi¹ce mV
	  if (send < 100)
		  result [1] = '0';
	  else
		  result [1] = (char)((send/100)%10) + 48;		//setki mV
	  if (send < 10)
		  result [2] = '0';
	  else
		  result [2] = (char)((send%100)/10) + 48;
	  if (send == 0)
		  result [3] = '0';
	  else
		  result [3] = (char)(send%10) + 48;
	  result [4] = ',';



  USART_puts(UART5, result);
}



void SendMeasTime(void)
{
	  static char resultT[13];

	  if(measHours < 10 )
		  resultT[0] = '0';
	  else
		  resultT[0] = (measHours/10) + 48;
	  if(measHours == 0 )
		  resultT[1] = '0';
	  else
		  resultT[1] = (measHours%10) + 48;

	  resultT[2] = ':';

	  if(measMinutes < 10 )
		  resultT[3] = '0';
	  else
		  resultT[3] = (measMinutes/10) + 48;
	  if(measMinutes == 0 )
		  resultT[4] = '0';
	  else
		  resultT[4] = (measMinutes%10) + 48;

	  resultT[5] = ':';

	  if(measSeconds < 10 )
		  resultT[6] = '0';
	  else
		  resultT[6] = (measSeconds/10) + 48;
	  if(measSeconds == 0 )
		  resultT[7] = '0';
	  else
		  resultT[7] = (measSeconds%10) + 48;

	  resultT[8] = ':';

	  if (measMs < 100)
		  resultT [9] = '0';
	  else
		  resultT [9] = (char)(measMiliseconds/100) + 48;
	  if (measMs < 10)
		  resultT [10] = '0';
	  else
		  resultT [10] = (char)((measMiliseconds%100)/10) + 48;
	  if (measMs == 0)
		  resultT [11] = '0';
	  else
		  resultT [11] = (char)(measMiliseconds%10) + 48;
	  resultT [12] = ',';

	  USART_puts(UART5, resultT);
}
void SendEnd(int send)
{

	  static char result[5];

	  if (send < 1000)
		  result [0] = '0';
	  else
		  result [0] = (char)(send/1000) + 48;		//tysi¹ce mV
	  if (send < 100)
		  result [1] = '0';
	  else
		  result [1] = (char)((send/100)%10) + 48;		//setki mV
	  if (send < 10)
		  result [2] = '0';
	  else
		  result [2] = (char)((send%100)/10) + 48;
	  if (send == 0)
		  result [3] = '0';
	  else
		  result [3] = (char)(send%10) + 48;
	  result [4] = ';';



  USART_puts(UART5, result);
}

void ConvertBPM()
{
	  int conv = (int)BPM;

	  if (conv < 1000)
		  resultBPM [0] = '0';
	  else
		  resultBPM [0] = (char)(conv/1000) + 48;		//tysi¹ce mV
	  if (conv < 100)
		  resultBPM [1] = '0';
	  else
		  resultBPM [1] = (char)((conv/100)%10) + 48;		//setki mV
	  if (conv < 10)
		  resultBPM [2] = '0';
	  else
		  resultBPM [2] = (char)((conv%100)/10) + 48;
	  if (conv == 0)
		  resultBPM [3] = '0';
	  else
		  resultBPM [3] = (char)(conv%10) + 48;


}
void ConvertHRV()
{

	  int conv = HRV;

	  if (conv < 1000)
		  resultHRV [0] = '0';
	  else
		  resultHRV [0] = (char)(conv/1000) + 48;		//tysi¹ce mV
	  if (conv < 100)
		  resultHRV [1] = '0';
	  else
		  resultHRV [1] = (char)((conv/100)%10) + 48;		//setki mV
	  if (conv < 10)
		  resultHRV [2] = '0';
	  else
		  resultHRV [2] = (char)((conv%100)/10) + 48;
	  if (conv == 0)
		  resultHRV [3] = '0';
	  else
		  resultHRV [3] = (char)(conv%10) + 48;


}

