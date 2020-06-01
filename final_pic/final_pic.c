#include <24FV16KM202.h>
#DEVICE ADC=8
#device icd=3
#FUSES FRC_PLL
#use delay(clock=32MHZ, internal=8mhz)
#use fast_io(B)
#USE RS232(UART2, BAUD = 115200, PARITY = N, BITS = 8, STOP = 1, TIMEOUT = 500))
#include <math.h>

#define LCD_ENABLE_PIN  PIN_A7
#define LCD_RS_PIN      PIN_B8
#define LCD_RW_PIN      PIN_B9
#define LCD_DATA4       PIN_B12
#define LCD_DATA5       PIN_B13
#define LCD_DATA6       PIN_B14
#define LCD_DATA7       PIN_B15

#include <LCD.C>
#include "keypad_scanner.c"

#define BUFFER_SIZE 200

/*-------------------------------------------------------------------------------------------------------------------*/
                                                      //global Variables for UART
int1 serial_flag = 0;      //signals a character is received
char ch;                   //character variable that holds the received byte from UART
int64 temp=0;              //temporary variable that is used in accumulating numeric value received from UART, especially used to store trigger value
int1 GUI_ready_to_receive=0;  //flag that is set when start sampling character is received
int1 GUI_ready_for_sampling_freq=0; //flag that is set when GUI is ready to receive sampling frequency
/*-------------------------------------------------------------------------------------------------------------------*/

//global variables for ADC and TIMER1 control
   //int1 start_sampling=0;
   int1 ADC_samples_ready=0;  //flag that is set when PIC stores all 200 samples
   int16 ADC_samples_index=0; //index for ADC_samples_buffer
   int32 timer_req=0;   //delay value that controls sampling process
   int16 ADC_samples_buffer[BUFFER_SIZE];    //buffer to store raw ADC samples
   
   int16 stop_value=0;  //variable that holds timer counter value before sampling
   int16 start_value=0; //variable that holds timer counter value after sampling
   
   int1 buffer_add_started=0; //flag that signals if sampling process is started or not
   int1 trigger_value_found=0;   //flag that singals if trigger value is found or not
   int1 rising_edge_found=0;  //flag that signals if rising edge is found or not which is the next sample after trigger value is found
   int16 a=0;  //variable that holds first triggered value
   int16 b=0;  //variable that holds value after first triggered value
   int16 c=0;  //variable that holds value after second triggered value
   int16 trigger_value=128;   //initial value for trigger value
   
//global variable for sampling control
   int1 clear_pressed=0;   //flag that signals whether clear button is pressed in GUI
/*-------------------------------------------------------------------------------------------------------------------*/

void lcd_display(char c)   //function that temporarily disables keypad interrupt and changes the direction of GPIO pins shared between Keypad and LCD
{    
   disable_interrupts(INT_EXT0);    //disable interrupt on External Interrupt
   set_pullup(false);   
   lcd_putc(c);   //displays the character on LCD terminal
   kbd_init();    //reinitializing keypad for next scanning process
   clear_interrupt(INT_EXT0);       //clearing interrupt on External INterrupt pin
   enable_interrupts(INT_EXT0);  //re-enabling interrrupt on External Interrrupt pin
}

/*-------------------------------------------------------------------------------------------------------------------*/

//interrupt handler for UART
#INT_RDA2
void isr_uart()
{
   ch=getc();     //receiving character from serial
   switch(ch)
   {
      case '*':      //Start sampling signal
         //start_sampling=1;
         GUI_ready_to_receive=1;
         clear_pressed=0;
         break;
      case '&':      //stop sampling signal
         GUI_ready_to_receive=0;
         ADC_samples_index=0;
         break;
      case '~':   //GUI is ready to receive data
         GUI_ready_to_receive=1;
         clear_pressed=0;
         break;
      case '%': //GUI is ready to receive max sampling freq data
         GUI_ready_for_sampling_freq=1;
         break;
      case 'A':
         timer_req=0; //max sampling freq=120KHz
         break;
      case 'B':
         timer_req=18; //sampling freq/4
         break;   
      case 'C':
         timer_req=85;   //sampling freq/16
         break;
      case 'D':
         timer_req=568;  //sampling freq/100
         break;
      case '(':   //start of trigger value
         temp=0;
         break;
      case ')':   
         //store the trigger value
         trigger_value=temp;
         ADC_samples_index=0;
         buffer_add_started=0;
         trigger_value_found=0;
         rising_edge_found=0;
         ADC_samples_ready=0;
         break;
      case 'c':   //clear button pressed
         clear_pressed=1;
         printf(lcd_display,"\fABORTED");
         break;
      default:
         break;
   }
   if(ch>='0' && ch<='9')  //converting the received character into numeric form
   {
      temp=temp * 10 + ch-'0';
   }
   //serial_flag=1;    //setting character received flag 
   
}

/*-------------------------------------------------------------------------------------------------------------------*/
//global variables for Keypad
char key = 0;  //character that holds scanned key
/*-------------------------------------------------------------------------------------------------------------------*/
void serial_display(char c)      //disables keypad interrupt temporarily to send character to GUI
{   
   disable_interrupts(INT_EXT0);     //disable interrupt on External Interrupt   
   set_pullup(false);
   putc(c);   //sending character to GUI
   kbd_init();    //reinitializing keypad for next scanning process    
   clear_interrupt(INT_EXT0);       //clearing interrupt on External INterrupt pin    
   enable_interrupts(INT_EXT0);  //re-enabling interrrupt on External Interrrupt pin 
}


/*-------------------------------------------------------------------------------------------------------------------*/

//interrupt handler for EXTINT0 used to detect key from keypad
#INT_EXT0 
void isr_ext() 
{    
   key = kbd_getc();          //receiving character from keypad
   disable_interrupts(INT_EXT0); 
   switch(key)
   {
      case '*':   //sampling started
         //start_sampling=1;
         GUI_ready_to_receive=1;
         GUI_ready_for_sampling_freq=1;
         clear_pressed=0;
         printf(serial_display,"*");   //sending sampling started signal to GUI
         break;
      case '#':   //sampling stopped
         //start_sampling=0;
         GUI_ready_to_receive=0;
         ADC_samples_index=0;
         printf(serial_display,"&");   //sending sampling stopped signal to GUI
         break;
      case '2':   //increase sampling frequency
         printf(serial_display,"+");   //sending signal to GUI to increase sampling frequency
         break;
      case '3':   //decrease sampling frequency
         printf(serial_display, "-");  //sending signal to GUI to decrease sampling frequency
         break;
      default:
         break;
   }
   kbd_init();    ///ground all rows
   clear_interrupt(INT_EXT0);
   enable_interrupts(INT_EXT0); 
}
/*-------------------------------------------------------------------------------------------------------------------*/


void main()
{  
   /*-------------------------------------------------------------------------------------------------------------------*/
   //start of setup and initializations
   lcd_init();    //initializing lcd
   
    //start of program
   printf(lcd_display,"\fECE 422 Final");
   //lcd_gotoxy(1,2);
   printf(lcd_display,"\nTiwari Susan");
   
   printf(serial_display,"ECE 422\nTiwari Susan");
   /*-------------------------------------------------------------------------------------------------------------------*/
   
   kbd_init();    //initializing keypad
   ext_int_edge(L_TO_H);
   
//!   clear_interrupt(INT_EXT0);
//!   clear_interrupt(INT_RDA2);
   enable_interrupts(INTR_GLOBAL);
   enable_interrupts(INT_RDA2); 
   enable_interrupts(INT_EXT0); 
   
   // Setup ADC
   setup_adc(ADC_CLOCK_DIV_2 | ADC_TAD_MUL_4);
   setup_adc_ports(sAN0 | VSS_VDD);
   
   // Setup Timer to sample ADC values precisely
   setup_timer1(T1_INTERNAL | T1_DIV_BY_1);
   
   //Setup Timer to calculate sampling frequency (Fs)
   //setup_ccp1(CCP_TIMER|CCP_TIMER_32_BIT);   //initializing ccp1 module as 32bit timer
   /*
   for any given frequency time required is calculated by following formula
      treq= Mclk/(2*fgiven);
      
      eg: f=1KHz , Mclk=32MHz, treq=32M/(2*1K)=16000
      so, timer needs to count 8000 in order to generate a square wave of 1KHz signal. 
   
   However, timer can only generate interrupt when 16-bit register value overflows from FFFFh to 0000h. 
   So, we need to set timer value using following formula: set_timer1(65535-treq)
   */

   //end of setup and initializations
   /*-------------------------------------------------------------------------------------------------------------------*/
  
   //local variables
   
   unsigned int32 timer_accumulator=0; //variable that holds the time required for sampling 
   int32 max_sampling_freq=0; //variable that stores the timer accumulated value to be sent to GUI
   float freq=0;  //variable that holds the sampling frequency

   /*-------------------------------------------------------------------------------------------------------------------*/
   while(1)
   {

      while(!ADC_samples_ready)  //while loop that loops until all 200 samples are stored in the buffer
      {
         
         start_value = get_timer1();   //storing current timer counter value before sampling
         delay_us(timer_req);          //applying delay to control sampling frequency
         if(buffer_add_started)  //determines if rising edge is found and reset of the samples should go in to buffer
         {
            if(ADC_samples_index==BUFFER_SIZE)  //determines if 200 samples are stored in the buffer
            {
               ADC_samples_index=0; //reinitializes the index to 0
               ADC_samples_ready=1; //set the flag to 1 to get out of the while loop and signal PIC to send the samples to GUI
               buffer_add_started=0;   //reset the flag in order to restart checking for trigger value next time
               max_sampling_freq=timer_accumulator;   //storin current timer_accumulator value to be sent to GUI
               timer_accumulator=0; //reset timer_accumulator value to 0 for next sampling process
            }
            else
            {
               ADC_samples_buffer[ADC_samples_index++]=read_ADC(ADC_START_AND_READ);   //storing current adc sample into buffer
               stop_value=get_timer1();   //captures current timer counter value after sampling
               timer_accumulator +=stop_value-start_value+14;  //finding the difference in start and stop timer value and accumulating in the variable along with a offset value to overcome time consumed by few instructions
            }
         }
         else
         {
            if(rising_edge_found)   //determines if two consecutive samples are found to be in increasing order  
            {
               c=read_ADC(ADC_START_AND_READ);
               if(c>=a)
               {
                  buffer_add_started=1;
                  ADC_samples_buffer[ADC_samples_index++]=a;
                  ADC_samples_buffer[ADC_samples_index++]=b;
                  ADC_samples_buffer[ADC_samples_index++]=c;
                  trigger_value_found=0;
                  rising_edge_found=0;
               }
               else
               {
                  trigger_value_found=0;
                  rising_edge_found=0;
                  timer_accumulator=0;
               }
               stop_value=get_timer1();
               timer_accumulator +=stop_value-start_value+14;
            }
            else
            {
               if(trigger_value_found) //determines if trigger value is found 
               {
                  b=read_ADC(ADC_START_AND_READ);
                  
                  if(b>=a)
                  {
                     rising_edge_found=1;
                  }
                  else
                  {
                     trigger_value_found=0;
                     timer_accumulator=0;
                  }
                  stop_value=get_timer1();
                  timer_accumulator +=stop_value-start_value+14;
               }
               else
               {
                  a=read_ADC(ADC_START_AND_READ);  //stores the current adc sample
                  
                  if(a==trigger_value) //determines if the current sample is equal to trigger value or not
                  {
                     trigger_value_found=1;
                  }
                  else
                     timer_accumulator=0;
                  
                  stop_value=get_timer1();
                  timer_accumulator +=stop_value-start_value+14;
               }
            }
         }
      }
      
      if(ADC_samples_ready)   //when 200 samples are collected and GUI is ready to receive data then sending data from samples buffer to GUI
      {
         if(GUI_ready_to_receive)   //determines whether GUI is ready to receive all samples
         {
            ADC_samples_ready=0;
            GUI_ready_to_receive=0;
            
            printf(serial_display,"!");   //sending signal to GUI to start collect samples
            for(int16 i=0; i<BUFFER_SIZE; i++)
            {
               //send the values from buffer to GUI for plot
               printf(serial_display,"%d ",ADC_samples_buffer[i]);
            }
            printf(serial_display,"@");   //end of buffer signal to GUI
            ADC_samples_index=0;
         }
    
      }  
      
      if(GUI_ready_for_sampling_freq && !clear_pressed)  //determines if GUI is ready to receive sampling frequency
      {
         GUI_ready_for_sampling_freq=0;
         printf(serial_display,"#%i$",max_sampling_freq);   //sending maximum sampling freq timer value
         freq = (float)((1.0/max_sampling_freq)*BUFFER_SIZE*1.6*Pow(10,7));
         printf(lcd_display,"\f%.1f Hz",freq);
      }
   
   }
}

