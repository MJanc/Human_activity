

#ifndef __ADDED_FUNC_H
#define __ADDED_FUNC_H

#include "stm32f4xx.h"
#include "main.h"

extern int measHours, measMinutes, measSeconds, measMiliseconds, measMs;
extern int sampleNumber;

extern volatile int samples[];
extern volatile int lastsamples[];
extern int period [];
extern double averPeriod;
extern double BPM;
extern int HRV;
extern int lastSample, lastSample2;
extern int sampleMs, lastSampleMs;

extern int sampleNow;

extern int max[5][2];
extern int samplesMax;
extern int samplesMin;
extern int voltageRange;
extern int filterSample;

extern char resultBPM[];
extern char resultHRV[];

extern char resultBPMShow[];
extern char resultHRVShow[];



extern double Ts;
extern double fg;
extern double RC;
extern double c[];
extern double d[];
extern double x[];
extern double y[];




void USART_puts(USART_TypeDef* USARTx, volatile char *s);


#endif
