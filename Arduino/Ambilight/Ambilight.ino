#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 13 // Output pin on the Arduino
#define NUM_LEDS 30 // The amount of LEDs used
#define STRIP 30 // The amount of LEDs on the strip

#define BAUD 115200 // This is the baud rate of which the program communicate with the Arduino
  
char color[NUM_LEDS * 3 + 1]; // Make room for all the color data plus one byte for start
int placeAt = 0; // This is used for the reading of color
int colorplace; // This is used for the assignment of colors to the strip

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(STRIP, PIN, NEO_GRB + NEO_KHZ800);

// IMPORTANT: To reduce NeoPixel burnout risk, add 1000 uF capacitor across
// pixel power leads, add 300 - 500 Ohm resistor on first pixel's data input
// and minimize distance between Arduino and first pixel.  Avoid connecting
// on a live circuit...if you must, connect GND first.

void setup() {
  #if defined (__AVR_ATtiny85__)
    if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
  #endif
  
  strip.begin();
  strip.setPixelColor(9, 1, 1, 1); // Just to see if the strip is working, this line can be removed
  strip.show();
  
  Serial.begin(BAUD);
}

void loop() {
  if(Serial.available()) // When something is sent over serial, this will be true
  {
    color[placeAt] = Serial.read(); // Read the serial into current placement space
    if(color[0] == 'a') // Check whether first byte is our start byte
    {
      placeAt++; // Increment our placement position
      if(placeAt > NUM_LEDS * 3) // Check if we have received colors for all our LEDs
      {
        for(int i = 0; i < NUM_LEDS; i++) // Go through each LED and set its color
        {
          colorplace = i * 3 + 1; // Calculate the position of each value
          strip.setPixelColor(i, color[colorplace], color[colorplace + 1], color[colorplace + 2]); // Set pixel(place, red, green, blue)
        }
        strip.show(); // Update the strip
        placeAt = 0; // Set the placement to zero for next message to be received
      }
    }
    else
    {
      placeAt = 0; // Is our first byte is not our start byte we will reset the placement until we get the starting byte
    }
  }
}
