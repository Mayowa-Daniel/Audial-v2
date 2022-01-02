#include "usart_lib.h"

void USART_init()
{
	unsigned int UBRR_val = (((F_CPU/(16*BAUD)))-1);
	
	//Configure baud rate
	UBRR0L = UBRR_val;
	UBRR0H = UBRR_val >> 8;
	
	UCSR0C = (1 << UCSZ00) | (1 << UCSZ01);
	
	//Set transmit bit
	UCSR0B |= (1 << TXEN0);
	
}


void USART_TXST(char * volumo)
{
	unsigned char i = 0;
	
	while(volumo[i] != '\0')
	{
		USART_TX(volumo[i]);
		
		i++;
	}	
}

void USART_TX(char single)
{
	while((UCSR0A & (1<<UDRE0))==0);
	UDR0 = single;
	
}


int converto(int val)
{
	return ((val*100.0)/1023);
}


