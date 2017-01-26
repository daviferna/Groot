#define pinLed 8

int status = 1;

void setup() {
  pinMode(pinLed, INPUT);

}

void loop() {

  if(status)
    digitalWrite(pinLed, HIGH);
  else
    digitalWrite(pinLed, LOW);

  delay(1000);
}
