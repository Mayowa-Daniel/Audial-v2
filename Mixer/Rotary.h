/*
 * rotary.h
 *
 * Created: 11/6/2021 14:46:03
 *  Author: Maya-2
 */ 

#ifndef ROTARY_H
#define ROTARY_H
#include <avr/io.h>
//define port where encoder is connected
#define ROTPORT PORTD
#define ROTDDR DDRD
#define ROTPIN PIND
//define rotary encoder pins
#define ROTPA PIND3
#define ROTPB PIND2
#define ROTPBUTTON	PB4
//define macros to check status
#define ROTA !((1<<ROTPA)&ROTPIN)
#define ROTB !((1<<ROTPB)&ROTPIN)
#define ROTCLICK !((1<<ROTPBUTTON)&ROTPIN)
//prototypes
void RotaryInit(void);
void RotaryCheckStatus(void);
uint8_t RotaryGetStatus(void);
void RotaryResetStatus(void);
#endif
