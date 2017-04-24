#include <DHT11.h>

#include <Servo.h>


#define IN1 13
#define IN2 12
#define IN3 11
#define IN4 10

#define SERVOPIN 9

#define LEVELECHO 7
#define LEVELTRIGGER 6

#define LIGHT A0

#define LIGHTRELE 2

#define TEMP 3

#define PUMP 8

DHT11 dht11(TEMP);

Servo irrigation;

int illumination;

int steps[4][4] = {
  {1,0,0,0},
  {0,1,0,0},
  {0,0,1,0},
  {0,0,0,1}

};

int step = 0;
bool direction = true;

float temp, hum;

void setup() {

  //WATER LEVEL
  Serial.begin(9600);
  pinMode(LEVELTRIGGER, OUTPUT);
  pinMode(LEVELECHO, INPUT);
  
  //STEPPER
  pinMode(IN1, OUTPUT);
  pinMode(IN2, OUTPUT);
  pinMode(IN3, OUTPUT);
  pinMode(IN4, OUTPUT);

  //IRRIGATION
  irrigation.attach(9);


  //LIGHT
   illumination = false;
   pinMode(LIGHT, INPUT);
   pinMode(LIGHTRELE, OUTPUT);


  //PUMP
  pinMode(PUMP, OUTPUT);

}



void loop() {
  goTo(1);
  turnLeft();
  setWaterOn();
  delay(3000);
  setWaterOff();
  turnCenter();
  goTo(1);
  delay(5000);

  
  /*
  goTo(1);
  turnRight();
  delay(2000);
  turnCenter();
  delay(2000);

  turnRight(); 
  delay(2000);
  turnLeft();
  delay(2000);
  turnCenter(); 
  delay(2000);

  for(int x = 0; x < 18500; x++){
    stepper();
    delay(2); 
  }
  

  direction = !direction;
  delay(3000);

  

  int cm = waterLevel();
  Serial.print("Distancia: ");
  Serial.println(cm);
  delay(1000);

  

  
  
  
  */

  /*
  int err;
  Serial.print("asdsa");
  if((err = dht11.read(hum, temp)) == 0)    // Si devuelve 0 es que ha leido bien
          {
             Serial.print("Temperatura: ");
             Serial.print(temp);
             Serial.print(" Humedad: ");
             Serial.print(hum);
             Serial.println();
          }
       else
          {
             Serial.println();
             Serial.print("Error Num :");
             Serial.print(err);
             Serial.println();
          }
  delay(1000);

  */

  /*
  int x = analogRead(LIGHT);
  Serial.print("Luz: ");
  Serial.println(x);
  delay(2000);
  digitalWrite(LIGHTRELE, LOW);
  delay(2000);

  if( x< 200)
    turnLightOn();
   else
    if(!illumination)
    turnLightOff();
    */
  
  
  
}

void turnLightOn(){
  digitalWrite(LIGHTRELE, HIGH);
  illumination = true;
}

void turnLightOff(){
  digitalWrite(LIGHTRELE, LOW);
  illumination = false;
}




int waterLevel(){
  long duration, distanceCm;

   digitalWrite(LEVELTRIGGER, LOW);  //para generar un pulso limpio ponemos a LOW 4us
   delayMicroseconds(4);
   digitalWrite(LEVELTRIGGER, HIGH);  //generamos Trigger (disparo) de 10us
   delayMicroseconds(10);
   digitalWrite(LEVELTRIGGER, LOW);
 
  duration = pulseIn(LEVELECHO, HIGH);  //medimos el tiempo entre pulsos, en microsegundos
 
  distanceCm = duration * 10 / 292/ 2;   //convertimos a distancia, en cm
  return distanceCm;
}        

void stepper(){
      digitalWrite( IN1, steps[step][ 0] );
      digitalWrite( IN2, steps[step][ 1] );
      digitalWrite( IN3, steps[step][ 2] );
      digitalWrite( IN4, steps[step][ 3] );
      setDirection();
}

void setDirection(){
  if(direction)
    step++;
  else
    step--;  

  step = ( step + 4 ) % 4;

}

void turnRight(){
  irrigation.write(0);
}

void turnLeft(){
  irrigation.write(170);
}

void turnCenter(){
  irrigation.write(80);
}

void goTo(int x){
  for(int steps = 0; steps < (x*6000); steps++){
      stepper();
      delay(2); 
  }

  direction = !direction;
  
}

void setWaterOn(){
  digitalWrite(PUMP, HIGH);
}

void setWaterOff(){
  digitalWrite(PUMP, LOW);
}


