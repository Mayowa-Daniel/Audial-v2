/*
 * Mixer.c
 *
 * Created: 7/31/2021 14:05:27
 * Author : Maya-2
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdlib.h>
#include "usart_lib.h"



int main(void)
{	
	int mixerinfo;
	char adc_value[5];
	ADMUX = 0x00;
	USART_init();
	//ADLAR should be 0 no reason for left adjust
	//channel 1/ADC0 for now
	//Enable ADC and set to Free running mode
	//free running mode broken
	//ADCSRA = (1 << ADEN) | (1 <<ADATE)  | (1 << ADSC)
	
	ADCSRA = (1 << ADEN);

    while(1) 
    {
		ADCSRA |= (1 << ADSC);
		while((ADCSRA & 1 << ADIF) == 0);
		ADCSRA |= (1<<ADIF);
		
		_delay_ms(500);


		mixerinfo = converto(ADC);
		itoa(mixerinfo, adc_value, 10);
		USART_TX(adc_value);
			

    }
}



