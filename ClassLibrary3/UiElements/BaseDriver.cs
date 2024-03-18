using System.Runtime.InteropServices;
using Allure.Net.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace ClassLibrary3
{
    public class BaseDriver
    {
        private IWebDriver driver;
        private string remoteWdUri = Utilities.selenoidUrl;

    
        public BaseDriver()
        {
            driver = StartBrowser();
        }
    
        private RemoteWebDriver StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            var nameSession = TestContext.CurrentContext.Test.Name;

            options.AddUserProfilePreference("browser.download.folderList", 2);
            options.AddUserProfilePreference("browser.download.manager.showWhenStarting", false);
            options.AddUserProfilePreference("browser.helperApps.alwaysAsk.force", false);
            options.AddUserProfilePreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.hzn-3d-crossword;video/3gpp;video/3gpp2;application/vnd.mseq;application/vnd.3m.post-it-notes;application/vnd.3gpp.pic-bw-large;application/vnd.3gpp.pic-bw-small;application/vnd.3gpp.pic-bw-var;application/vnd.3gp2.tcap;application/x-7z-compressed;application/x-abiword;application/x-ace-compressed;application/vnd.americandynamics.acc;application/vnd.acucobol;application/vnd.acucorp;audio/adpcm;application/x-authorware-bin;application/x-athorware-map;application/x-authorware-seg;application/vnd.adobe.air-application-installer-package+zip;application/x-shockwave-flash;application/vnd.adobe.fxp;application/pdf;application/vnd.cups-ppd;application/x-director;applicaion/vnd.adobe.xdp+xml;application/vnd.adobe.xfdf;audio/x-aac;application/vnd.ahead.space;application/vnd.airzip.filesecure.azf;application/vnd.airzip.filesecure.azs;application/vnd.amazon.ebook;application/vnd.amiga.ami;applicatin/andrew-inset;application/vnd.android.package-archive;application/vnd.anser-web-certificate-issue-initiation;application/vnd.anser-web-funds-transfer-initiation;application/vnd.antix.game-component;application/vnd.apple.installe+xml;application/applixware;application/vnd.hhe.lesson-player;application/vnd.aristanetworks.swi;text/x-asm;application/atomcat+xml;application/atomsvc+xml;application/atom+xml;application/pkix-attr-cert;audio/x-aiff;video/x-msvieo;application/vnd.audiograph;image/vnd.dxf;model/vnd.dwf;text/plain-bas;application/x-bcpio;application/octet-stream;image/bmp;application/x-bittorrent;application/vnd.rim.cod;application/vnd.blueice.multipass;application/vnd.bm;application/x-sh;image/prs.btif;application/vnd.businessobjects;application/x-bzip;application/x-bzip2;application/x-csh;text/x-c;application/vnd.chemdraw+xml;text/css;chemical/x-cdx;chemical/x-cml;chemical/x-csml;application/vn.contact.cmsg;application/vnd.claymore;application/vnd.clonk.c4group;image/vnd.dvb.subtitle;application/cdmi-capability;application/cdmi-container;application/cdmi-domain;application/cdmi-object;application/cdmi-queue;applicationvnd.cluetrust.cartomobile-config;application/vnd.cluetrust.cartomobile-config-pkg;image/x-cmu-raster;model/vnd.collada+xml;text/csv;application/mac-compactpro;application/vnd.wap.wmlc;image/cgm;x-conference/x-cooltalk;image/x-cmx;application/vnd.xara;application/vnd.cosmocaller;application/x-cpio;application/vnd.crick.clicker;application/vnd.crick.clicker.keyboard;application/vnd.crick.clicker.palette;application/vnd.crick.clicker.template;application/vn.crick.clicker.wordbank;application/vnd.criticaltools.wbs+xml;application/vnd.rig.cryptonote;chemical/x-cif;chemical/x-cmdf;application/cu-seeme;application/prs.cww;text/vnd.curl;text/vnd.curl.dcurl;text/vnd.curl.mcurl;text/vnd.crl.scurl;application/vnd.curl.car;application/vnd.curl.pcurl;application/vnd.yellowriver-custom-menu;application/dssc+der;application/dssc+xml;application/x-debian-package;audio/vnd.dece.audio;image/vnd.dece.graphic;video/vnd.dec.hd;video/vnd.dece.mobile;video/vnd.uvvu.mp4;video/vnd.dece.pd;video/vnd.dece.sd;video/vnd.dece.video;application/x-dvi;application/vnd.fdsn.seed;application/x-dtbook+xml;application/x-dtbresource+xml;application/vnd.dvb.ait;applcation/vnd.dvb.service;audio/vnd.digital-winds;image/vnd.djvu;application/xml-dtd;application/vnd.dolby.mlp;application/x-doom;application/vnd.dpgraph;audio/vnd.dra;application/vnd.dreamfactory;audio/vnd.dts;audio/vnd.dts.hd;imag/vnd.dwg;application/vnd.dynageo;application/ecmascript;application/vnd.ecowin.chart;image/vnd.fujixerox.edmics-mmr;image/vnd.fujixerox.edmics-rlc;application/exi;application/vnd.proteus.magazine;application/epub+zip;message/rfc82;application/vnd.enliven;application/vnd.is-xpr;image/vnd.xiff;application/vnd.xfdl;application/emma+xml;application/vnd.ezpix-album;application/vnd.ezpix-package;image/vnd.fst;video/vnd.fvt;image/vnd.fastbidsheet;application/vn.denovo.fcselayout-link;video/x-f4v;video/x-flv;image/vnd.fpx;image/vnd.net-fpx;text/vnd.fmi.flexstor;video/x-fli;application/vnd.fluxtime.clip;application/vnd.fdf;text/x-fortran;application/vnd.mif;application/vnd.framemaker;imae/x-freehand;application/vnd.fsc.weblaunch;application/vnd.frogans.fnc;application/vnd.frogans.ltf;application/vnd.fujixerox.ddd;application/vnd.fujixerox.docuworks;application/vnd.fujixerox.docuworks.binder;application/vnd.fujitu.oasys;application/vnd.fujitsu.oasys2;application/vnd.fujitsu.oasys3;application/vnd.fujitsu.oasysgp;application/vnd.fujitsu.oasysprs;application/x-futuresplash;application/vnd.fuzzysheet;image/g3fax;application/vnd.gmx;model/vn.gtw;application/vnd.genomatix.tuxedo;application/vnd.geogebra.file;application/vnd.geogebra.tool;model/vnd.gdl;application/vnd.geometry-explorer;application/vnd.geonext;application/vnd.geoplan;application/vnd.geospace;applicatio/x-font-ghostscript;application/x-font-bdf;application/x-gtar;application/x-texinfo;application/x-gnumer");
            options.AddUserProfilePreference("browser.download.manager.focusWhenStarting", false);
            options.AddUserProfilePreference("browser.download.manager.useWindow", false);
            options.AddUserProfilePreference("browser.download.manager.showAlertOnComplete", false);

            Dictionary<string, object> selenoidOptions = new Dictionary<string, object>();
            selenoidOptions.Add("enableVNC", true);
            selenoidOptions.Add("browser", "chrome");
            
            selenoidOptions.Add("version", RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "mac-arm" : "120.0");

            selenoidOptions.Add("W3C", false);
            selenoidOptions.Add("name", $" {DateTime.Now:HH:mm:ss} | ТЕСТЗОЛТО - {Utilities.baseUrl} | {nameSession}");
            selenoidOptions.Add("platform", "Any");
            selenoidOptions.Add("env", new List<string>() { "TZ=Europe/Moscow" });
            selenoidOptions.Add("download.default_directory", Path.GetFullPath(@"Downloads"));
            
            options.AddAdditionalOption("selenoid:options", selenoidOptions);
            options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            options.AddArgument("start-maximized");
            options.AddArgument("no-sandbox");
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("disable-notifications");
            options.AddUserProfilePreference("autofill.profile_enabled", false);
            options.AddUserProfilePreference("download.prompt.for.download", false);

            var waiting = TimeSpan.FromMinutes(10);

            var remoteWebDriver = new RemoteWebDriver(new Uri(remoteWdUri + "wd" + Path.DirectorySeparatorChar + "hub"), options.ToCapabilities(), waiting);

            return remoteWebDriver;
        }

        public void Quit()
        {
            driver.Quit();
        }

        public void Dispose()
        {
            driver.Dispose();
        }
     
        #region навигация
        public void GoToUrl(string? url = null)
        {
            if (url != null) 
                driver.Url = Utilities.baseUrl + url;
            
            driver.Navigate().Refresh();
        }
        #endregion
        
        public IWebElement GetEl(By locator, int secondsToWait = 10)
        {
            while (secondsToWait > 0)
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
                if (elements.Count > 0)
                {
                    foreach (IWebElement element in elements)
                    {
                        return element;
                    }
                }
                System.Threading.Thread.Sleep(1000);
                secondsToWait -= 1;
            }
            throw new NoSuchElementException($"На странице не найден элемент: {locator.ToString()};");
        }
        
        public void ScrollToElement(By locator)
        {
            try
            {
                Actions action = new Actions(driver);
                IWebElement element = GetEl(locator, 30);
                action.ScrollToElement(element).Perform();
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(1000);
                throw new Exception($"Элемент {locator.ToString()} не найден!");
            }
        }
        
        public IWebElement FillField(By locator, string value, int secondsToWait = 10)
        {
            while (secondsToWait > 0)
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    
                    element.SendKeys(value);
                    
                    return element;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                    secondsToWait -= 1;
                }
            }
            throw new Exception($"Element {locator.ToString()} not fillable!");
        }
        
        public void WaitUntilPageIsLoaded()
        {
            bool areEqual = false;
            while (!areEqual)
            {
                var old_pagesource = driver.PageSource;
                Thread.Sleep(500);
                var new_pagesource = driver.PageSource;

                if (old_pagesource == new_pagesource)
                {
                    areEqual = true;
                }
            }
        }
        public IWebElement Click(By locator, int secondsToWait = 10)
        {
            while (secondsToWait > 0)
            {
                try
                {
                    IWebElement element = driver.FindElement(locator);
                    element.Click();
                    WaitUntilPageIsLoaded();
                    return element;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                    secondsToWait -= 1;
                }
            }
            throw new Exception($"Element {locator.ToString()} not clickable!");
        }
        
        public IReadOnlyCollection<IWebElement> GetEls(By locator, int secondsToWait = 3)
        {
            while (secondsToWait > 0)
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
                if (elements.Count > 0)
                {
                    return elements;
                }
                Thread.Sleep(1000);
                secondsToWait -= 1;
            }
            throw new NoSuchElementException($"На странице не найден элемент: {locator.ToString()};");
        }
        
        public int GetElsCount(By locator, int secToWait = 3)
        {
            try
            {
                IReadOnlyCollection<IWebElement> elements = GetEls(locator, secToWait);
                return elements.Count;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}

