
#include "stm32f4xx_it.h"

uint16_t capture = 0;
extern __IO uint16_t CCR1_Val;

extern int measHours, measMinutes, measSeconds, measMiliseconds, measMs;

void NMI_Handler(void)
{
}


void HardFault_Handler(void)
{
  /* Go to infinite loop when Hard Fault exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Memory Manage exception.
  * @param  None
  * @retval None
  */
void MemManage_Handler(void)
{
  /* Go to infinite loop when Memory Manage exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Bus Fault exception.
  * @param  None
  * @retval None
  */
void BusFault_Handler(void)
{
  /* Go to infinite loop when Bus Fault exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Usage Fault exception.
  * @param  None
  * @retval None
  */
void UsageFault_Handler(void)
{
  /* Go to infinite loop when Usage Fault exception occurs */
  while (1)
  {}
}

/**
  * @brief  This function handles Debug Monitor exception.
  * @param  None
  * @retval None
  */
void DebugMon_Handler(void)
{}

/**
  * @brief  This function handles SVCall exception.
  * @param  None
  * @retval None
  */
void SVC_Handler(void)
{}

/**
  * @brief  This function handles PendSV_Handler exception.
  * @param  None
  * @retval None
  */
void PendSV_Handler(void)
{}

/**
  * @brief  This function handles SysTick Handler.
  * @param  None
  * @retval None
  */
void SysTick_Handler(void)
{}

void TIM3_IRQHandler(void)
{

	 if (TIM_GetITStatus(TIM3, TIM_IT_Update) == SET)
	 {
	 TIM_ClearITPendingBit(TIM3, TIM_IT_Update);

	 UpdateTime();
	 }

}

void UpdateTime()
{
	measMs += 5;
	if(measMs>=10000)
	{
		measMs = 0;

	}


	measMiliseconds += 5;
	if(measMiliseconds >= 1000)
	{
		measSeconds++;
		measMiliseconds = 0;
	}
	if(measSeconds == 60)
	{
		measMinutes++;
		measSeconds = 0;
	}
	if(measMinutes == 60)
	{
		if(++measHours == 24)
			measHours = 0;
		measMinutes = 0;
	}

}

