long dis;
long tiem;


void setup() {
  Serial.begin(9600);
  pinMode(10, OUTPUT); //salida del pulso generado por el sensor ultrasónico
  pinMode(9, INPUT);//entrada del pulso generado por el sensor ultrasónico
}

void loop() {
  digitalWrite(10,LOW);//recibimiento del pulso.
  delayMicroseconds(5);
  digitalWrite(10, HIGH);//envío del pulso.
  delayMicroseconds(10);
  tiem = pulseIn(9, HIGH);//fórmula para medir el pulso entrante.
  dis = long(0.017*tiem);//fórmula para calcular la distancia del sensor ultrasónico.
  if(dis < 400){
      Serial.println(dis);
  }

  delay(250);
}
