# Selenium-Mbunit-SeleniumGrid

## How config Selenium Grid?

1 -  download Selenium Standalone from http://www.seleniumhq.org/download/.
2 - In the remote machine or Virtual machine open two consoles.
3 - In the first console execute the next line: java -jar selenium-server-standalone-2.45.0.jar -role hub //In the Standalone folder
3 - In the second console execute the next line: java -jar selenium-server-standalone-2.45.0.jar -role node  -hub http://localhost:4444/grid/register -Dwebdriver.chrome.driver=chromedriver.exe  -Dwebdriver.ie.driver=IEDriverServer.exe //In the Standalone folder
