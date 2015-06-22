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
        HomePage home;
        /// <summary>
        /// Login in the application
        /// </summary>
        [SetUp]
        public void InitHomeTestCases()
        {
            home = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the Shopping Cart is displayed.
        /// </summary>
        [Test]
        public void UserSeesHisShoppingCart()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.AreMyDxElementsPresents());
        }
    }

[TestFixture]: Specifies that class represent a test fixture(Test class).

[Parallelizable]: Specifies that the corresponding test can be run in parallel with other parallelizable test.


**2-** Go to the AssemblyInfo.cs Property file

**3-** Add the next properties : DegreeOfParallelism and Parallelizable

Example:

     [assembly: DegreeOfParallelism(4)]

     [assembly: Parallelizable(TestScope.Self)]

DegreeOfParallelism: Specifies the maximun number of concurrent threads to use when tests are run in parallel for all tests in the test assembly.

TestScope: Specifies the scope to which certain attribute apply.

**TestScope types:**

Self: Applies to the corresponding test only.
All: Applies to the corresponding test and his descendants.
Descendants: Applies of the descendants for the corresponding test.
