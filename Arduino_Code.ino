
   const int relayPin1 = 2;
const int relayPin2 = 3;
const int relayPin3 = 4;
const int relayPin4 = 5;

// the setup routine runs once when you press reset:
void setup() {                
  // initialize the digital pin as an output.
  pinMode(relayPin1, OUTPUT);  
  pinMode(relayPin2, OUTPUT); 
  pinMode(relayPin3, OUTPUT); 
  pinMode(relayPin4, OUTPUT);
  Serial.begin(9600);
}

// the loop routine runs over and over again forever:
void loop() { 
  if (Serial.available())
  {
    byte data;
    data = Serial.read();
  
    switch (data) {
    case 0:    // your hand is on the sensor
    digitalWrite(relayPin1, LOW);
    digitalWrite(relayPin2, LOW);
    digitalWrite(relayPin3, LOW);
    digitalWrite(relayPin4, LOW);
    break;
    
  case 1:    // your hand is close to the sensor
    digitalWrite(relayPin1,HIGH );
    digitalWrite(relayPin2, HIGH);
    digitalWrite(relayPin3, LOW);
    digitalWrite(relayPin4, LOW);
    break;
  case 2:    // your hand is a few inches from the sensor
    digitalWrite(relayPin1,HIGH );
    digitalWrite(relayPin2, HIGH);
    digitalWrite(relayPin3, HIGH);
    digitalWrite(relayPin4, LOW);
    
  case 3:    // your hand is nowhere near the sensor
    digitalWrite(relayPin1,HIGH );
    digitalWrite(relayPin2, HIGH);
    digitalWrite(relayPin3, HIGH);
    int var = 0;
     while(var < 200){
  // do something repetitive 200 times
     digitalWrite(relayPin4, HIGH);
     delay(1000);
     digitalWrite(relayPin1,LOW);
     delay(1000);
     var++;
}  
   
    }

}
}

