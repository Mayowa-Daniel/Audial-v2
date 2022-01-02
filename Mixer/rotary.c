/*
 * rotary.c
 *
 * Created: 11/6/2021 14:52:59
 *  Author: Maya-2
 */ 

#include "rotary.h"

static uint8_t rotarystatus=0;
static uint8_t wait=0;
uint8_t rotarycount = 0;

void RotaryInit(void)
{
	//set pins as input
	ROTDDR &= ~((1<<ROTPA)|(1<<ROTPB)|(1<<ROTPBUTTON));
	//enable internal pull-ups for rotary and pots
	ROTPORT |= (1<<ROTPA)|(1<<ROTPB)|(1<<ROTPBUTTON)|(1<<PORTC2)|(1<<PORTC3);;
}

void RotaryCheckStatus(void)
{
	//reading rotary and button
	//check if rotation is left
	if(ROTA & (!wait))
	wait=1;
	if (ROTB & ROTA & (wait))
	{
		rotarystatus=2;
		wait=2;
	}
	else if(ROTA & (!ROTB) & wait)
	{
		rotarystatus=1;
		wait=2;		
	}
	if ((!ROTA)&!(ROTB)&(wait==2))
	wait=0;
	//check button status
	if (ROTCLICK)
	{
		for(volatile uint16_t x=0;x<0x0FFF;x++);
		if (ROTCLICK)
		rotarystatus=3;
		
	}
}

//return button status
uint8_t RotaryGetStatus(void)
{
	return rotarystatus;
}
//reset status
void RotaryResetStatus(void)
{
	rotarystatus=0;
}
