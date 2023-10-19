#include <Accelerometer.h>
#include <Barometer.h>
#include <BaseIMU.h>
#include <Compass.h>
#include <GOST4401_81.h>
#include <Gyroscope.h>
#include <MadgwickAHRS.h>
#include <TroykaIMU.h>

#include <TroykaMeteoSensor.h>

TroykaMeteoSensor meteoSensor;
Barometer barometer;
void setup() {
  // открываем последовательный порт
  Serial.begin();
  meteoSensor.begin();
  barometer.begin();
  // ждём открытия порта
  
}

void loop() {
  if (Serial.available()) {
    Serial.println("Serial init OK");
    Serial.println("Meteo Sensor and barometer init OK");
  }
  // считываем данные с датчика
  int stateSensor = meteoSensor.read();
  
  Serial.println("Barometer's pressure:\t");
  Serial.print(barometer.readPressureMillimetersHg());
  Serial.println("Barometer's altitude:\t");
  Serial.print(barometer.readAltitude());
  Serial.println("Barometer's temp:\t");
  Serial.print(barometer.readTemperatureC());



  switch (stateSensor) {
    case SHT_OK:
      // выводим показания влажности и температуры
      Serial.println("Data sensor is OK");
      Serial.print("Temperature = ");
      Serial.print(meteoSensor.getTemperatureC());
      Serial.println(" C \t");
      Serial.print("Humidity = ");
      Serial.print(meteoSensor.getHumidity());
      Serial.println(" %\r\n");
      break;
    // ошибка данных или сенсор не подключён
    case SHT_ERROR_DATA:
      Serial.println("Data error or sensor not connected");
      break; 
    // ошибка контрольной суммы
    case SHT_ERROR_CHECKSUM:
      Serial.println("Checksum error");
      break;
  }
  // ждём одну секунду
  delay(5000);
}
