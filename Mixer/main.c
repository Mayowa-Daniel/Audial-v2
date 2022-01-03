/*
 * Mixer Full.c
 *
 * Created: 11/11/2021 07:05:43
 * Author : Maya-2
 */ 

#include <avr/io.h>
#include <stdlib.h>
#include "usart_lib.h"
#include "rotary.h"

int8_t rotaryval=0;
int8_t vol;
char mixer_vol[5];
uint8_t channel = 0x02;
char currchannel[5];



int main(void)
{	
	//Initialize the input pins for the rotary encoder
    RotaryInit();
	//Initialize USART  
    USART_init();
	//Enable ADC pin
    ADCSRA = (1 << ADEN);
	
	//set potentiometer pins(A2 and A3) as input pins
	//DDRC |= (0<<PORTC2) | (0<<PORTC3);
	
    while(1)
    {
		
		RotaryCheckStatus();
		if(RotaryGetStatus() == 2)
		{
			rotaryval--;
		}
		else if(RotaryGetStatus() == 1)
		{
			rotaryval++;
		}
		
			
		if(rotaryval < 0)
		{
			rotaryval = 0;
		}
		else if(rotaryval > 100)
		{
			rotaryval = 100;
		}
		
		//Convert rotaryval to a USART transmittable string	
		itoa(rotaryval, mixer_vol, 10);
		USART_TXST(mixer_vol);
		USART_TX('|');
		RotaryResetStatus();
		
		//Only go to channel A4
		while(channel <= 4)
		{
			ADCSRA = (1 << ADEN);
			ADMUX = (1 << REFS0) | (0 << REFS1) | channel;
			
			//noisy ADC pins lead to stupid ADC values
			//for some fucking reason you need to dump the ADC value TWICE
			for (int i=0; i < 2; i++)
			{
				//Start ADC Conversion
				ADCSRA |= (1 << ADSC);
				//ADMUX |= (channel << 1);
				//while(ADCSRA & (1<<ADSC));
				//Wait till conversion is complete
				while((ADCSRA & 1 << ADIF) == 0);
				ADCSRA |= (1<<ADIF);
			}
						
			
			vol = converto(ADC);
			itoa(vol, mixer_vol, 10);
			//itoa(ADC, mixer_vol, 10);
			//itoa(channel, currchannel, 10);
			//USART_TX(currchannel);
			USART_TXST(mixer_vol);
			if (channel != 4)
			{
				USART_TX('|');
			}
			
			
			//increment ADC channel/ go to next ADC pin
			channel++;
		}
		
		//transmit end-of-line character
		USART_TXST("\r");
		//send newline character
		USART_TXST("\n");
		
		//Start over from ADC2
		channel = 0x02;
		
    }
}

