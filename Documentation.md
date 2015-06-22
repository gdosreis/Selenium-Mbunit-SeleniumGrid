# Selenium-Mbunit-SeleniumGrid


## How configure Selenium Grid?

**1-**  download Selenium Standalone from http://www.seleniumhq.org/download/.

**2-** In the remote machine or Virtual machine open two consoles.

**3-** In the first console execute the next line: 

     java -jar selenium-server-standalone-2.45.0.jar -role hub  
    //In the Standalone folder

**4-** In the second console execute the next line: 

    java -jar selenium-server-standalone-2.45.0.jar -role node  -hub http://localhost:4444/grid/register -Dwebdriver.chrome.driver=chromedriver.exe  -Dwebdriver.ie.driver=IEDriverServer.exe  
    //In the Standalone folder.

**5-** Enter to localhost:4444/grid/console, if the page is loaded,  the server started correctly. // In this page could be find the machine url that will be used to instantiate the RemoteWebDriver. Ex- id: http://192.168.6.83:5555.


### Parameters

    java -jar selenium-server-standalone-2.45.0.jar -role node  -hub http://localhost:4444/grid/register
  
The default port the hub uses to listen for new requests is port 4444. This is why port 4444 was used in the URL for locating the hub. Also the use of ‘localhost’ assumes your node is running on the same machine as your hub

    -Dwebdriver.chrome.driver=chromedriver.exe  -Dwebdriver.ie.driver=IEDriverServer.exe
  
-Dwebdriver.chrome.driver is used to set up the chromedriver path.

-Dwebdriver.ie.driver is used to set up the InternetExplorerDriver path.

    -port xxxx
  
-port  is used to set up the port used by the hub.

    -browser: browserName={android, chrome, firefox, htmlunit, internet explorer, iphone, opera} version={browser version} firefox_binary={path to executable binary} chrome_binary={path to executable binary} maxInstances={maximum number of browsers of this type} platform={WINDOWS, LINUX, MAC}

-browser is used to specify an additional browser that to be used and set the browser settings.

    -maxSession x
    
-maxSession is used to set the maximum number of browsers that can run in parallel on the node.




##How configure MBunit?

**1-** Install the Gallio-MBunit pakage

**2-** Add the MBunit and Gallio reference within the reference automation project.



### How parallelize the test case execution?

**1-** Set each test classes with the next tags: TestFixture and Parallelizable.
 
  Example:

    /// <summary>
    /// This class checks the Home page functionality
    /// </summary>
    [TestFixture,Parallelizable]
    public class HomeTestCases: TestBase
    {
       ........
    }

[TestFixture]: Specifies that class represent a test fixture(Test class).

[Parallelizable]: Specifies that the corresponding test can be run in parallel with other parallelizable test.

**2-** Set each test case with the [Test] tag, preconditions with [SetUp] and postconditions with [TearDown] tag.

 Example:
  
        /// <summary>
        /// Login in the application
        /// </summary>
        [SetUp]
        public void InitHomeTestCases()
        {
            home = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the Username link behavior.
        /// </summary>
        [Test]
        public void UserClicksOnUsername()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.AreMyDxElementsPresents());
        }

        /// <summary>
        /// Logout from the application.
        /// </summary>
        [TearDown]
        public void HomeTestCasesCleanUp()
        {
            home.LogOut();
        }

[Test]: Specifies that a method represents a single test.

[SetUp]: Specifies a method that is to be invoked before each test.

[TearDown]: Specifies a method that is to be invoked after each test.

**3-** Go to the AssemblyInfo.cs Property file

**4-** Add the next properties : DegreeOfParallelism and Parallelizable

Example:

     [assembly: DegreeOfParallelism(4)]

     [assembly: Parallelizable(TestScope.Self)]

DegreeOfParallelism: Specifies the maximun number of concurrent threads to use when tests are run in parallel for all tests in the test assembly.

TestScope: Specifies the scope to which certain attribute apply.

**TestScope types:**

Self: Applies to the corresponding test only.

All: Applies to the corresponding test and his descendants.

Descendants: Applies of the descendants for the corresponding test.


##How Run MBunit test cases?

**1-** Download the Gallio tool from: https://code.google.com/p/mb-unit/downloads/list

**2-** Install the downloaded tool. 

**3-** Open the Icarus GUI Test Runner tool.

**4-** Build the Automation project from Visual Studio.

**5-** Import the dll project.

**6-** Run the corresponding test cases.


##How configure a remote driver?

**1-** First we have to set the driver Capabilities
 
 -We have to indicate the OS that will be run the test cases,it's indicate in the Selenium Grid console.-> http://www.screencast.com/t/Ar9OX37eH

 Example:

           DesiredCapabilities capabilities = new DesiredCapabilities();
           capabilities.SetCapability(CapabilityType.Platform, PlatformType.Vista);

-We have to indicate the browser in that will be run the test cases.

Example:

           DesiredCapabilities capabilities = new DesiredCapabilities();
           capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
In c# the corresponding names are:

           Internet Explorer:"internet explorer"
     
           Google Chrome:"chrome"
     
           Firefox:"firefox"

-We can indicate the browser version.

Example:

           DesiredCapabilities capabilities = new DesiredCapabilities();
           capabilities.SetCapability(CapabilityType.Version, "40");

Other capabilities: 
 
 IsJavaScriptEnabled: Enable or disable javascript executions in the coresponding browser.
 AcceptSslCertificates: Indicate if the browser accepts ssl Certificates.
 Proxy: Indicate the browser proxy.
 TakesScreenshot: Indicate if the browser can take screenshots.
