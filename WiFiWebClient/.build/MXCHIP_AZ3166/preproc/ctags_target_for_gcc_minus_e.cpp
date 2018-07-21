# 1 "c:\\Users\\SANG-ASUS\\Documents\\GitHub\\MSDNHackShanghai\\WiFiWebClient\\WiFiWebClient.ino"
# 1 "c:\\Users\\SANG-ASUS\\Documents\\GitHub\\MSDNHackShanghai\\WiFiWebClient\\WiFiWebClient.ino"

# 3 "c:\\Users\\SANG-ASUS\\Documents\\GitHub\\MSDNHackShanghai\\WiFiWebClient\\WiFiWebClient.ino" 2
# 4 "c:\\Users\\SANG-ASUS\\Documents\\GitHub\\MSDNHackShanghai\\WiFiWebClient\\WiFiWebClient.ino" 2

HTS221Sensor *ht_sensor;
DevI2C *ext_i2c;

char ssid[] = "Nokia7";
char pass[] = "123456789@";
int keyIndex = 0;

int status = WL_IDLE_STATUS;

char server[] = "192.168.43.70";

WiFiClient client;

void setup()
{

  ext_i2c = new DevI2C(D14, D15);
  ht_sensor = new HTS221Sensor(*ext_i2c);
  ht_sensor->init(
# 23 "c:\\Users\\SANG-ASUS\\Documents\\GitHub\\MSDNHackShanghai\\WiFiWebClient\\WiFiWebClient.ino" 3 4
                 __null
# 23 "c:\\Users\\SANG-ASUS\\Documents\\GitHub\\MSDNHackShanghai\\WiFiWebClient\\WiFiWebClient.ino"
                     );
  //Initialize serial and wait for port to open:
  Serial.begin(115200);

  // check for the presence of the shield:
  if (WiFi.status() == WL_NO_SHIELD)
  {
    Serial.println("WiFi shield not present");
    // don't continue:
    while (true);
  }


  // attempt to connect to Wifi network:
  while (status != WL_CONNECTED)
  {
    Serial.println("Attempting to connect to SSID: ");
    Serial.println(ssid);
    // Connect to WPA/WPA2 network. Change this line if using open or WEP network:
    status = WiFi.begin(ssid, pass);

    // wait 10 seconds for connection:
    delay(10000);
  }
  Serial.println("Connected to wifi");
  delay(2000);

  Serial.println("\nStarting connection to server...");
  // if you get a connection, report back via serial:
  if (client.connect(server, 2018))
  {
    Serial.println("connected to server");
    delay(1000);
  }
}

void loop()
{

  uint8_t buff[32];

  // if there are incoming bytes available
  // from the server, read them and print them:
  while (client.available())
  {
    int ret = client.read(buff, sizeof(buff));
    if (ret <= 0)
      break;
    for(int i = 0; i < ret; i++)
    {
      //串口照着打印
      Serial.write((char)buff[i]);
    }
  }

  showHumidTempSensor();
  delay(1000);
  // //掉到死循环了
  // Serial.println();
  // Serial.println("disconnecting from server.");

  // client.stop();
  // Screen.println("disconnected");

  // // do nothing forevermore:
  // while (true);
}
void showHumidTempSensor()
{
  ht_sensor->reset();
  float temperature = 0;
  ht_sensor->getTemperature(&temperature);
  //convert from C to F
  temperature = temperature*1.8 + 32;
  float humidity = 0;
  ht_sensor->getHumidity(&humidity);

  char buff[128];
  snprintf(buff, 128, "Environment \r\n Temp:%sF    \r\n Humidity:%s%% \r\n          \r\n",f2s(temperature, 1), f2s(humidity, 1));
  Screen.print(buff);
  snprintf(buff,128,"%s,%s",f2s(temperature, 1), f2s(humidity, 1));
  client.println(buff);
  Serial.println(buff);
}

void printWifiStatus() {
  // print the SSID of the network you're attached to:
  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());

  // print your WiFi shield's IP address:
  IPAddress ip = WiFi.localIP();
  Serial.print("IP Address: ");
  Serial.println(ip);

  // print the received signal strength:
  long rssi = WiFi.RSSI();
  Serial.print("signal strength (RSSI):");
  Serial.print(rssi);
  Serial.println(" dBm");
}
