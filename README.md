# Human_activity
System Monitoring Human Activity

System monitoring human activity based on STM32F4 Discovery evaluation board. 

This project uses STM32F4 to receive optical signal from sensor (representing change in blood vessel expansion) to calculate BPM and HRV and watch running signal. Microcontroller also applies signal filtering (digital IIR filter, 2nd order) to monitor non circulatory activity like breathing. Application prepared in C# allows to receive signal via COM port, save and read written files.

Signal from non-invasive optical sensor is transferred to ADC3 in microcontroller. Timer is regularly triggering ADC to convert signal and controls time of measurement. After every conversion, all current results (probe, time, BPM, HRV, filtered signal) are sent via UART5. After getting 1000 probes of signal parameteres (BPM, HRV) are calculated. Meanwhile, signal with current BPM and HRV are shown on STM32F4 Disc0 TFT LCD.

Prepared PC application displays results sent via COM port. App scans active COM ports and allows user to choose active one. There is also a possibility to save signal (blank path means no saving). Application allows also to see files written in the past (with choose what user wants to see + functionality of FFT of signal).

TIM_ADC_test (STM32F4 project - System Workbench for STM32, SPL):
*main.c contains definition of functions: calculating BPM, calculating digital filter, serving DMA event, and while(1) controlling TFT display
*config.c contains definition of functions configuring UART, ADC and Timer
*added_func.c contains functions related to preparing signal to send

odbiorUART (C# app):
*FormChart - main window of the program
*Form1 - functionality of reading saved signal

