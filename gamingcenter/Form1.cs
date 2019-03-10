using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gamingcenter
{
    public partial class Form1 : Form
    {
        static string MySqlConnectionString = "datasource=localhost;port=3306;username=root;password=;database=gc1";
        MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
        public Form1()
        {
            InitializeComponent();
            onloadCb();
           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void createTables()
        {
            string q1 = "CREATE TABLE IF NOT EXISTS EMPLOYEES( EmployeesID INT NOT NULL AUTO_INCREMENT, Name VARCHAR(255) NOT NULL, LastName VARCHAR(255) NOT NULL, Gender VARCHAR(255) NOT NULL, BirthDate DATE NOT NULL, Phone INT(20) NOT NULL, Address VARCHAR(255) NOT NULL, Rating VARCHAR(255) NOT NULL, Branches VARCHAR(255) NOT NULL, Status VARCHAR(255) NOT NULL, Salary VARCHAR(255) NOT NULL, PRIMARY KEY(EmployeesID));";
            string q2 = "CREATE TABLE IF NOT EXISTS CUSTOMERS(CustomerID INT NOT NULL AUTO_INCREMENT,Name VARCHAR(255) NOT NULL,LastName VARCHAR(255) NOT NULL,Gender VARCHAR(255) NOT NULL,BirthDate DATE NOT NULL,Phone INT(20) NOT NULL,Email VARCHAR(255),Address VARCHAR(255) NOT NULL,City VARCHAR(255) NOT NULL,Country VARCHAR (50) NOT NULL,PostalCode INT NOT NULL,Payment VARCHAR(255),PRIMARY KEY(CustomerID));";
            string q3 = "CREATE TABLE IF NOT EXISTS CONSOLE(ConsoleID INT NOT NULL AUTO_INCREMENT,Name VARCHAR(255) NOT NULL,Brand VARCHAR(255) NOT NULL,Capacity VARCHAR(255) NOT NULL,Release_Date DATE NOT NULL,Quantity INT NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Description TEXT NOT NULL,Rating VARCHAR(255) NOT NULL,Warranty INT NOT NULL,PRIMARY KEY(ConsoleID));";
            string q4 = "CREATE TABLE IF NOT EXISTS LAPTOP(LaptopID INT NOT NULL AUTO_INCREMENT,Brand VARCHAR(255) NOT NULL,GraphicCard VARCHAR(255) NOT NULL,Processor VARCHAR(255) NOT NULL,RAM VARCHAR(255) NOT NULL,HardDisk VARCHAR(255) NOT NULL,Quantity INT NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Rating VARCHAR(255),PRIMARY KEY(LaptopID));";
            string q5 = "CREATE TABLE IF NOT EXISTS PCPeripheral(PCPeripheralID INT NOT NULL AUTO_INCREMENT,Category VARCHAR(255) NOT NULL,Type VARCHAR(255) NOT NULL,Name VARCHAR(255) NOT NULL,Brand VARCHAR(255),Quantity INT NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Rating VARCHAR(255) NOT NULL,PRIMARY KEY(PCPeripheralID));";
            string q6 = "CREATE TABLE IF NOT EXISTS GAMES(GameID INT NOT NULL AUTO_INCREMENT,Type VARCHAR(255) NOT NULL,Name VARCHAR(255) NOT NULL,Platform VARCHAR(255) NOT NULL,Release_Date DATE NOT NULL,Requirements TEXT NOT NULL,Genre VARCHAR(255) NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Quantity INT NOT NULL,Description TEXT NOT NULL,PRIMARY KEY(GameID));";
            string q7 = "CREATE TABLE IF NOT EXISTS MotherBoards(MotherBoardID INT NOT NULL AUTO_INCREMENT,Model VARCHAR(255) NOT NULL,FormatOfBoard VARCHAR(255) NOT NULL,Chipset VARCHAR(255) NOT NULL,Slot VARCHAR(255) NOT NULL,TypeOfRAM VARCHAR(255) NOT NULL,PCI_Slot VARCHAR(255) NOT NULL,USB_ports VARCHAR (255) NOT NULL,SATA_connectors VARCHAR(255) NOT NULL,IntegredCards VARCHAR(255) NOT NULL,Warranty INT NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Rating VARCHAR(255) NOT NULL,Quantity INT NOT NULL,PRIMARY KEY(MotherBoardID));";
            string q8 = "CREATE TABLE IF NOT EXISTS GraphicCards(GraphicCardID INT NOT NULL AUTO_INCREMENT,Brand VARCHAR(255) NOT NULL,Model VARCHAR(255) NOT NULL,TypeOfRAM VARCHAR(255) NOT NULL,RAM VARCHAR(255) NOT NULL,Connectors VARCHAR(255) NOT NULL,Cooling VARCHAR(255) NOT NULL,Speed VARCHAR(255) NOT NULL,Directx VARCHAR(255) NOT NULL,Slot VARCHAR(255) NOT NULL,Warranty INT NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Rating VARCHAR(255) NOT NULL,Quantity INT NOT NULL,PRIMARY KEY(GraphicCardID));";
            string q9 = "CREATE TABLE IF NOT EXISTS Processors(ProcessorID INT NOT NULL AUTO_INCREMENT,Name VARCHAR(100) NOT NULL,Brand VARCHAR(255) NOT NULL,Slot VARCHAR(255) NOT NULL,WorkingTact VARCHAR(255) NOT NULL,Cache VARCHAR(255) NOT NULL,Cores VARCHAR(255) NOT NULL,Threads VARCHAR(255) NOT NULL,Warranty INT NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Quantity INT NOT NULL,Rating VARCHAR(255) NOT NULL,PRIMARY KEY(ProcessorID));";
            string q10 = "CREATE TABLE IF NOT EXISTS HardDisks(HardDiskID INT NOT NULL AUTO_INCREMENT,Brand VARCHAR(255) NOT NULL,Type VARCHAR(255) NOT NULL,Model VARCHAR(255) NOT NULL,Capacity VARCHAR(255) NOT NULL,SpeedWR VARCHAR(255) NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Quantity INT NOT NULL,Rating VARCHAR(255) NOT NULL,PRIMARY KEY(HardDiskID));";
            string q11 = "CREATE TABLE IF NOT EXISTS Ram(RamID INT NOT NULL AUTO_INCREMENT,Brand VARCHAR(255) NOT NULL,Type VARCHAR(255) NOT NULL,Model VARCHAR(255) NOT NULL,Capacity VARCHAR(255) NOT NULL,Speed VARCHAR(255) NOT NULL,Warranty INT NOT NULL,Profit DOUBLE NOT NULL,Price DOUBLE NOT NULL,Rating VARCHAR(255) NOT NULL,Quantity INT NOT NULL,PRIMARY KEY(RamID));";
            string q12 = "CREATE TABLE IF NOT EXISTS BRANCHES(BranchID INT NOT NULL AUTO_INCREMENT,Name VARCHAR(255) NOT NULL,Country VARCHAR(255) NOT NULL,City VARCHAR(255) NOT NULL,EmployeesID INT NOT NULL,PRIMARY KEY(BranchID),FOREIGN KEY(EmployeesID) REFERENCES EMPLOYEES(EmployeesID));";
            string q13 = "CREATE TABLE IF NOT EXISTS ORDERS(OrderID INT NOT NULL AUTO_INCREMENT,OrderDate DATE NOT NULL,Status VARCHAR(255) NOT NULL,Payment VARCHAR(255) NOT NULL,CustomerID INT NOT NULL,EmployeesID INT NOT NULL,PRIMARY KEY (OrderID),FOREIGN KEY (CustomerID) REFERENCES CUSTOMERS(CustomerID),FOREIGN KEY(EmployeesID) REFERENCES EMPLOYEES(EmployeesID));";
            string q14 = "CREATE TABLE IF NOT EXISTS ORDERDETAILS(OrderDetID INT NOT NULL AUTO_INCREMENT,CustomerID INT,EmployeesID INT,LaptopID INT,GameID INT,ConsoleID INT,OrderID INT,PCPeripheralID INT,MotherBoardID INT,GraphicCardID INT,ProcessorID INT,HardDiskID INT,RamID INT,QuantityOrdered INT NOT NULL,PriceTotal DOUBLE NOT NULL,PRIMARY KEY(OrderDetID),FOREIGN KEY(CustomerID) REFERENCES CUSTOMERS(CustomerID),FOREIGN KEY(EmployeesID) REFERENCES EMPLOYEES(EmployeesID),FOREIGN KEY(LaptopID) REFERENCES LAPTOP(LaptopID),FOREIGN KEY(GameID) REFERENCES GAMES(GameID),FOREIGN KEY(ConsoleID) REFERENCES CONSOLE(ConsoleID),FOREIGN KEY(OrderID) REFERENCES ORDERS(OrderID),FOREIGN KEY(PCPeripheralID) REFERENCES PCPeripheral(PCPeripheralID),FOREIGN KEY(MotherBoardID) REFERENCES MotherBoards(MotherBoardID),FOREIGN KEY(GraphicCardID) REFERENCES GraphicCards(GraphicCardID),FOREIGN KEY(ProcessorID) REFERENCES Processors(ProcessorID),FOREIGN KEY(HardDiskID) REFERENCES HardDisks(HardDiskID),FOREIGN KEY(RamID) REFERENCES Ram(RamID));";


            string[] queries = new string[14] { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12, q13, q14 };

            for (int i = 0; i<14; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(queries[i]);
                runQuery(queries[i]);
                databaseConnection.Close();
                if (i == 13)
                {
                    MessageBox.Show("Success");
                }
            }

            
        }

        MySqlDataReader myReader;

        private void fillTable()
        {
            string q1 = "INSERT INTO EMPLOYEES(EmployeesID,Name,LastName,Gender,BirthDate,Phone,Address,Rating,Branches,Status,Salary) VALUES(NULL,'Marko','Rajic','Male',19931204,0601112232,'Alekse Santica 52',3,'GamingCentar','Full Time','500$'),(NULL,'Pera','Peric','Male',19960110,060112232,'Tolstojeva 15',4,'GamingCentar','Full Time','300$'),(NULL,'Mika','Mikic','Male',19930901,0604433256,'Narodnog Fronta 29',5,'GamingCentar','Full Time','325$'),(NULL,'Zika','Zivkovic','Male',19910303,063001002,'Cara Dusana 19',4,'GamingCentar','Full Time','400$'), (NULL,'John','Adams','Male',19920102,0601122333,'Alekse Santica 50',3,'GamingCentar','Full Time','310$'),(NULL,'Lebron','James','Male',19890909,040112242,'Hadzi Ruminova',4,'GamingCentar','Full Time','390$'),(NULL,'Russell','Westrbrook','Male',19810109,040551121,'Cara Lazara 19','2','GamingCentar','Full Time','300$'),(NULL,'Josh','Howard','Male',19900619,0401100983,'Bulevar Oslobodjenja 58',3,'GamingCentar','Full Time','560$'),(NULL,'Svetlana','Djukanovic','Female',19941109,0601118832,'Sekspirova 15',4,'GamingCentar','Full Time','440$'),(NULL,'Milica','Milic','Female',19911003,060001122,'Papa Pavla 11','3','GamingCentar','Full Time','500$'),(NULL,'Kristina','Pajic','Female',19910909,0605671223,'Danila Kisa 7',1,'GamingCentar','Full Time','580$'),(NULL,'Marija','Maric','Female',19930715,0600123221,'Lasla Gala 8',4,'GamingCentar','Full Time','550$'),(NULL,'Luka','Zec','Male',19970809,0621112232,'Bolmanska 15','3','GamingCentar','Full Time','300$'),(NULL,'Denisa','Stefan','Female',19940801,0652212232,'Heroija Pinkija 19','4','GamingCentar','Full Time','600$'),(NULL,'Mirjana','Milicevic','Female',19801103,0662122334,'Fejes Klare 15',5,'GamingCentar','Full Time','500$'),(NULL,'Milos','Milosevic','Male',19930704,0611112232,'Sremska 14',4,'GamingCentar','Full Time','483$'),(NULL,'Nesa','Ilic','Male',19810504,0633332232,'Skadarska 58',4,'GamingCentar','Full Time','385$'),(NULL,'Natalija','Nesic','Female',19931211,0634442232,'Ljubljanska 90',4,'GamingCentar','Full Time','520$'),(NULL,'Dunja','Visnjic','Male',19851002,0671113342,'Jase Tomica 15',3,'GamingCentar','Full Time','387$'),(NULL,'Vanja','Markovic','Female',19901109,0633412232,'Ive Milutinovica 18',5,'GamingCentar','Full Time','380$')";
            runQuery(q1);
            databaseConnection.Close();

            string q2 = "INSERT INTO CUSTOMERS(CustomerID,Name,LastName,Gender,BirthDate,Phone,Email,Address,City,Country,PostalCode,Payment) VALUES(NULL,'Ana','Banana','Female',19800911,0605654431,'anabanana@gmail.com', 'Sremska 26','Vrsac','Serbia',26300,'Master-Card'), (NULL,'Milan','Milin','Male',19830112,0603334431,'milan@gmail.com', 'Kosovska 89','Novi Sad','Serbia',21000,'Dina-Card'), (NULL,'Nenad','Nesic','Male',19901111,063431231,'nenad@gmail.com', 'Cvijiceva 12','Timisoar','Romania',11000,'Visa-Card'), (NULL,'Milica','Mikic','Female',19921229,0614231231,'milica@gmail.com', 'Bulevar Vojvode Stepe 28/11','Budapest','Hungary',11000,'Visa-Card'), (NULL,'Nebojsa','Markovic','Male',19930206,064342994,'nebojsa@gmail.com', 'Cika Stevina 8/10','Zagreb','Croatia',21000,'Master-Card'), (NULL,'Svetlana','Milin','Female',19940811,0619981231,'svetlana@gmail.com', 'Krusevacka 198','Beograd','Serbia',11000,'Visa-Card'), (NULL,'Aleksandra','Nikic','Female',19980717,0694312312,'aca@gmail.com', 'Vojnicki Trg 12/24','Wienna','Austria',26300,'Cash'), (NULL,'Aleksa','Aleksic','Male',19900411,063431231,'Aleksic@gmail.com', 'Jevrejska 80','Novi Sad','Serbia',21000,'Cash'), (NULL,'Aleksandra','Draskovic','Female',19910611,0674111999,'Nenad@gmail.com', 'Djusina 19','Beograd','Serbia',11000,'Cash'), (NULL,'Petar','Petrovic','Male',19920108,0655553131,'petarp@gmail.com', 'Petra Drapsina 84','Valjevo','Serbia',14000,'Visa-Card'), (NULL,'Milenka','Mikic','Female',19710128,063513221,'milenko@gmail.com', 'Fruskogorska 111','Budapest','Hungary',21000,'Master-Card'), (NULL,'Mladen','Dabic','Male',19930322,0640098221,'mladen@gmail.com', 'Doza Djerdja 56/20','Novi Sad','Serbia',21000,'Cash'), (NULL,'Milos','Gojkovic','Male',19950311,0620212000,'milos@gmail.com', 'Dositejeva 4','Zagreb','Croatia',26300,'Dina-Card'), (NULL,'Ruzica','Sokic','Female',19660607,0628800913,'ruzica@gmail.com', 'Feliksa Milekera 14','Wienna','Austria',18000,'Visa-Card'), (NULL,'Tamara','Petrovic','Female',19870808,0611319931,'tamara@gmail.com', 'Tolstojeva 55/40','Timisoar','Romania',16000,'Master-Card'), (NULL,'Nikolina','Nikolic','Female',19940114,0601441000,'nikolina@gmail.com', 'Pariske Komune 8/12','Nis','Serbia',21000,'Visa-Card'), (NULL,'Petra','Petrovic','Female',19900525,0604043001,'petra@gmail.com', 'Lole Ribara 176','Wienna','Austria',18000,'Visa-Card'), (NULL,'Zarko','Zarkovic','Male',19681102,0650505115,'zarko@gmail.com', 'Savski Venac 18','Beograd','Serbia',11000,'Dina-Card'), (NULL,'Danijela','Glisovic','Female',19910325,0604043090,'danijela@gmail.com', 'Mise Dimitrijevica 19','Novi Sad','Serbia',21000,'Visa-Card'), (NULL,'Aleksandra','Vucic','Female',19791002,0605051199,'aleks11@gmail.com', 'Cvetna 10','Vrsac','Serbia',26300,'Visa-Card');";
            runQuery(q2);
            databaseConnection.Close();

            string q3 = "INSERT INTO CONSOLE(ConsoleID,Name,Brand,Capacity,Release_Date,Quantity,Profit,Price,Description,Rating,Warranty) VALUES(NULL,'Playstation 4 PRO','Sony','1TB',20180101,80,60.99,599.99,'PS4 PRO je trenutno najbolja gaming konzola na tržištu. Sav ovaj jaki hardver ispod haube neće ostati neiskorišćen, jer će konzola podržavati igranje u 4K, tojest 2160p rezoluciji. Dosadašnje igre će biti potpuno kompatibilne sa novom konzolom i biće ”razvučene” na tu rezoluciju, dok će sve buduće igre moći da imaju podršku za 4K ukoliko developeri tako odluče.','Excellent',36), (NULL,'Playstation 4 SLIM','Sony','1TB',20170505,65,37.35,197.99,'Osam jezgara AMD-ovog procesora i 8GB GDDR5 memorije pokreću najnoviju konzolu iz Sony-ja. Novi redizajnirani Dualshock 4 sa touch površinom, ugradjenim zvučnikom, i jackom za slušalice samo je deo inovacija. Ukoliko imate PS Vita konzolu, možete preko nje igrati igre koje imate na Playstation 4. PS4 poseduje mogućnost da koristi izdvojene ekrane na mobilnim uredjajima poput Android telefona i tablet računara i mogućnost korišćenja kamere (nije uračunata u cenu) koja registruje vaše pokrete, glas i zvukove i prenosi vas direktno u igru. PS4 kamera omogućava da ceo sistem kontrolišete glasom.','Poor',36), (NULL,'Playstation 4 SLIM','Sony','500GB',20150210,150,69.00,369.99,'Da napomenemo, ovo je ista konzola koja je objavljena pre tri godine, samo tanja i lakša, ali nikakvih hardverskih promena nema. PlayStation 4 Slim dolazi ipak sa neznatno ažuriranim DualShock 4 kontrolerom koji sada ima redizajniranu svetlosnu traku koja je vidljiva sa prednje strane. Takođe, potrošnja struje je značajno smanjena.','Very Good',36),(NULL,'XBOX 360','Microsoft','4GB',20100221,150,39.99,169.00,'neki dugacak text','Good',24),(NULL,'XBOX 360 E','Microsoft','16GB',20120809,90,32.99,211.99,'neki dugacak text 2','Very Good',24), (NULL,'XBOX 360 E Chipped','Microsoft','250GB',20150910,50,56.99,289.99,'neki dugacak text 3','Very Good',24),(NULL,'XBOX One Black','Microsoft','1TB',20170303,110,30.99,335.99,'neki dugacak text 4','Excellent',24), (NULL,'XBOX One Slim White','Microsoft','500GB',20150304,50,39.99,309.99,'neki dugacak text 5','Excellent',24),(NULL,'XBOX One + Kinetic','Microsoft','1TB',20170101,33,45.99,405.99,'neki dugacak text 6','Excellent',24), (NULL,'Playstation 3 Slim Chipped','Sony','120GB',20100909,70,40.99,229.99,'neki dugacak text 7','Good',36),(NULL,'Playstation 3 Slim','Sony','500GB',20120717,50,49.99,249.99,'neki dugacak text 8','Excellent,',36), (NULL,'Playstation 3 SLIM','Sony','320GB',20110210,41,39.99,229.99,'neki dugacak text 10','Very Good',36),(NULL,'Playstation 3 SLIM','Sony','250GB',20131220,21,45.99,201.99,'neki dugacak text 11','Good',24), (NULL,'Playstation 3 Phat','Sony','80GB',20080629,89,30.99,138.99,'neki dugacak text 12','Very Good',24),(NULL,'Playstation 3 Chipped','Sony','1TB',20110210,8,50.99,289.99,'neki dugacak text 13','Very Good',24), (NULL,'PlayStation Portable','Sony','8GB',20040213,15,30.99,90.99,'neki dugacak text 14','Excellent',24), (NULL,'PlayStation Portable','Sony','16GB',20080924,50,30.99,109.99,'neki dugacak text 15','Excellent',24), (NULL,'PlayStation Portable','Sony','32GB',20111201,33,53.99,153.99,'neki dugacak text 16','Excellent',24), (NULL,'Nintendo Wii','Nintendo','64GB',20100829,70,54.99,179.99,'neki dugacak text 7','Good',36), (NULL,'Nintendo GameCube Unique ','Nintendo','/',20010914,1,140.99,999.99,'unikat', 'Excellent,',36);";
            runQuery(q3);
            databaseConnection.Close();

            string q4 = "INSERT INTO PCPeripheral(PCPeripheralID,Category,Type,Name,Brand,Quantity,Profit,Price,Rating)VALUES( NULL,'Mouse','Cable-Gaming','Genesis GX68','Natec Genesis',250,14.99,32.99,'Very Good'),( NULL,'Mouse','Bluetooth','Hyperx PulsFire FPS','Hyperx',198,9.99,26.99,'Good'),( NULL,'Keyboard','Cable-Keyboard','Genesis Rhod','Genesis',88,6.30,18.00,'Fair'),( NULL,'Headphones','Cable-HP','Hama HS 200 139900','Hama',40,5.99,17.99,'Fair'),( NULL,'Headphones','Cable-HP','Genius HS-M300','Genius',50,3.99,12.99,'Good'),( NULL,'Mouse','Bluetooth','MX Master 2S','Logitech',10,24.99,105.99,'Excellent'),( NULL,'Mouse','Cable-Gaming','GM-300 ','Nacon',25,8.99,35.99,'Very Good'),( NULL,'Keyboard','Cable-Gaming','SGB-3000-KKMF1','Cooler Master',18,14.99,59.99,'Excellent'),( NULL,'Keyboard','Cable-Gaming','GXT 285 GADA','Trust',13,11.99,42.99,'Very Good'),( NULL,'Keyboard','Bluetooth','THUNDER PRO','MS Industrial',15,13.99,52.99,'Excellent'),( NULL,'Mouse','Cable-Gaming','G305','Logitech',15,12.99,59.99,'Excellent'),( NULL,'Mouse','Cable-Gaming','G602','Logitech',22,7.99,35.99,'Very Good'),( NULL,'Mouse','Bluetooth','G403','Logitech',11,10.99,50.99,'Excellent'),( NULL,'Microphone','Cable','S5 Black','Tracer',55,1.99,7.99,'Fair'),( NULL,'Microphone','Cable','MI-10','A4',33,2.99,12.99,'Good'),( NULL,'Microphone','Cable','CLM 2 Black','iDance',22,3.99,19.99,'Very Good'),( NULL,'Joystick','Cable-Gaming','FOX','Tracer',27,4.99,24.99,'Very Good'),( NULL,'Joystick','Cable-Gaming','PV58','Genesis',29,5.99,29.99,'Very Good'),( NULL,'Joystick','Bluetooth','F710-','Logitech',9,12.99,49.99,'Excellent'),( NULL,'Web Camera','Cable','C525,8mpx','Logitech',18,12.99,44.99,'Excellent'); ";
            runQuery(q4);
            databaseConnection.Close();

            string q5 = "INSERT INTO GAMES(GameID,Type,Name,Platform,Release_Date,Requirements,Genre,Profit,Price,Quantity,Description) VALUES( NULL,'PC-Game','World of Warcraft Battle for Azeorth','PC','20180814','neki dugacak tekst1','MMORPG',13.99,44.99,120,'neki dugacak tekst1'),( NULL,'Console-Game','God of War','PS4','20180420','neki dugacak tekst2','Action',9.98,52.00,57,'neki dugacak tekst2'),( NULL,'PC-Game','GTA V','PC','20130917','neki dugacak tekst3','Action',12.99,54.99,15,'neki dugacak tekst3'),( NULL,'PC-Game','Fortnite','PC','20170725','neki dugacak tekst4','Action',6.99,44.99,18,'neki dugacak tekst4'),( NULL,'Console-Game','FIFA 2018','PS4','20170925','neki dugacak tekst5','Sport',13.99,64.99,22,'neki dugacak tekst5'),( NULL,'Console-Game','NBA 2k18','PS4','20170915','neki dugacak tekst6','Sport',11.80,59.99,24,'neki dugacak tekst6'),( NULL,'Console-Game','Dark Souls','PS4','20110922','neki dugacak tekst7','Action',5.80,32.99,13,'neki dugacak tekst7'),( NULL,'Console-Game','Uncharted 4','PS4','20160526','neki dugacak tekst8','Action',7.99,35.80,18,'neki dugacak tekst8'),( NULL,'Console-Game','FarCry 5','PS4','20170327','neki dugacak tekst9','Action',17.99,49.99,22,'neki dugacak tekst9'),( NULL,'Console-Game','Metal Gear Solid V: The Phantom Pain','PS4','20150901','neki dugacak tekst10','Action',5.99,34.99,14,'neki dugacak tekst10'),( NULL,'Console-Game','Rise of the Tomb Raider','PS4','20151110','neki dugacak tekst11','Action',7.99,37.99,20,'neki dugacak tekst 11'),( NULL,'Console-Game','Call of Duty: Modern Warfare Remastered','PS4','20161104','neki dugacak tekst12','Action',8.99,40.99,28,'neki dugacak tekst12'),( NULL,'PC-Game','Overwatch','PC','20160524','neki dugacak tekst13','Action',9.99,40.99,15,'neki dugacak tekst13'),( NULL,'PC Game','Batman: Arkham City','PC','20111018','neki dugacak tekst14','Action',8.99,34.99,22,'neki dugacak tekst14'),( NULL,'PC-Game','Dishonored','PC','20121009','neki dugacak tekst 15','Action',4.99,24.99,19,'neki dugacak tekst15'),( NULL,'PC-Game','Doom','PC','20160513','neki dugacak tekst 16','Action',7.99,29.99,30,'neki dugacak tekst16'),( NULL,'PC-Game','Diablo 3','PC','20120515','neki dugacak tekst 17','RPG',7.99,39.99,27,'neki dugacak tekst 17'),( NULL,'PC-Game','The Elder Scrolls V: Skyrim','PC','20111204','neki dugacak tekst 18','RPG',8.99,41.99,17,'neki dugacak tekst 18'),( NULL,'Console-Game','Monster Hunter: World','PS4','20180128','neki dugacak tekst 19','Action',12.99,49.99,41,'neki dugacak tekst 19'),( NULL,'Console-Game','The Witcher 3: Wild Hunt','PS4','20150519','neki dugacak tekst 20','Action',9.99,44.99,33,'neki dugacak20');";
            runQuery(q5);
            databaseConnection.Close();

            string q6 = "INSERT INTO MotherBoards(MotherBoardID,Model,FormatOfBoard,Chipset,Slot,TypeOfRAM,PCI_Slot,USB_ports,SATA_connectors,IntegredCards,Warranty,Profit,Price,Rating,Quantity) VALUES(Null,'Z170 Extreme6+','ATX','Z170 Extreme6+','1151','DDR4','3xPCI Express 3.0 x1 Slots','2xUSB 2.0 Headers, 1xUSB 3.0 Header','6 x SATA3 6.0 Gb/s connector(s)',' Intel® HD Graphics',36,25.87,123.44,'Excellent',60), (Null,'A320M PRO-VD/S','Micro-ATX','AMD® A320 Chipset','AM4','DDR4','2x PCI-Express 3.0 (x1)','2x USB 2.0 Type-A, 4x USB 3.1 Gen1 Type-A','6 x SATA3 6.0 Gb/s connector(s)',' 7th Gen A-series/ Athlon™',24,19.99,93.00,'Good',18), (Null,'B360 PRO4','ATX',' Intel® B360','1151','DDR4','3x PCI Express 3.0 x1','1x USB 3.1, 2x USB 2.0', '6x SATA3','Zavisno od procesora.',48,29.99,117.00,'Very Good',31), (Null,'Z370 Killer SLI','ATX','Intel® Z370','1151','DDR4','4x PCI Express 3.0 x1 Slots','1x USB 3.1 Gen1 Header, 2x USB 2.0 Headers, 1x Front Panel Type C USB 3.1', '6x SATA3 6.0 Gb/s Connectors',' Intel HD',54,41.99,199.99,'Excellent',12), (Null,'Z370M Pro4','Micro-ATX','Intel® Z370','1151','DDR4','2x PCI Express 3.0 x1 Slots', '4x USB 3.1 Gen1 Type-A Ports, 1x USB 3.1 Gen1 Type-C Port, 1x USB 2.0 Port.', '6x SATA3 6.0 Gb/s','Intel® UHD Graphics',42,38.99,139.99,'Very good',40), (Null,'ROG STRIX Z370-F GAMING','ATX','Intel® Z370','1151','DDR4','1x PCIe 3.0/2.0 x16, 4x PCIe 3.0/2.0 x1', '2x USB 3.1 Gen 2 Type-A + USB Type-CTM, 2x USB 3.1 Gen 1 (blue), 2x USB 2.0','6x SATA3 6.0 Gb/s', 'Zavisno od procesora',36,68.99,269.99,'Excellent',23), (Null,'B250GT3','Micro ATX','Intel B250','1151','DDR4','2x PCI-E 3.0 x1 Slot', '4x USB 3.0, 2x USB 2.0','6x SATA3 6.0 Gb/s', 'Zavisno od procesora',24,23.99,89.99,'Good',18),(Null,'Asus PRIME B360-PLUS','ATX','Intel® B360','1151','DDR4','1x PCIe 3.0/2.0 x16, 4x PCIe 3.0/2.0 x1', '2x USB 3.1 Gen 2 Type-A + USB Type-CTM, 2x USB 3.1 Gen 1 (blue), 2x USB 2.0','4x SATA3 6.0 Gb/s', 'Zavisno od procesora',24,29.99,109.99,'Very good',27), (Null,'Asus ROG MAXIMUS X APEX Z370 ','E-ATX','Intel® Z370','1151','DDR4','3 x PCIe 3.0 x16, 4x PCIe 3.0/2.0 x1', '2x USB 3.1 Gen 2 Type-A + USB Type-CTM, 2x USB 3.1 Gen 1 (blue), 2x USB 2.0','4x SATA3 6.0 Gb/s', 'Zavisno od procesora',48,129.99,439.99,'Excellent',12), (Null,'Gigabyte GA-E3800N','Mini-ITX','AMD E2-3800','1151','DDR3','3 x PCIe 3.0 x16,2x USB 3.1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','2x SATA3 6.0 Gb/s', 'Zavisno od procesora',24,12.99,49.99,'Poor',22), (Null,'Asus TUF Z370-PRO GAMING','ATX','Intel® Z370','1151','DDR4','2 x PCIe 3.0/2.0 x16,2x USB 3.1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',36,57.99,169.99,'Very Good',18), (Null,'MSI H110M PRO-D','ATX','Intel® Z370','1151','DDR4','5x PCI Express 3.0,USB 3.1 2 (Tip A) Gen1 USB 2.0 2x', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',36,17.99,74.99,'Fair',23), (Null,'Gigabyte X299 AORUS Gaming 3 rev.1.0 ','ATX','Intel® X299 Express','1151','DDR4','5 x PCIe 3.0/2.0 x16,4 x USB 3.1 Gen1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',36,157.99,469.99,'Excellent',8), (Null,'MSI B250M BAZOOKA PLUS','microATX','Intel® B250 Express ','1151','DDR4','1 x PCIe 3.0/2.0 ,2 x USB 3.1 Gen1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',36,21.99,119.99,'Good',34), (Null,'Asus RAMPAGE VI EXTREME','E-ATX ',' Intel® X299 Express','1151','DDR4','5 x PCIe 3.0/2.0 x16,4 x USB 3.1 Gen1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',36,168.99,949.99,'Excellent',2), (Null,'MSI Z170A TOMAHAWK ','ATX',' Intel® 2066','1151','DDR4','5 x PCIe 3.0/2.0 x16,4 x USB 3.1 Gen1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',24,47.99,299.99,'Very Good',14), (Null,'GIGABYTE GA-H110M-S2V','ATX','Intel® 2066','1151','DDR4','1 x PCIe 3.0/2.0 x16,4 x USB 3.1 Gen1, 2x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','4x SATA 6Gb/s', 'Zavisno od procesora',48,11.99,59.99,'Poor',11), (Null,'ASUS PRIME B250M-C','ATX',' Intel® 2066','1151','DDR4','5 x PCIe 3.0/2.0 x16,4 x USB 3.1 Gen1, 4x USB 2.0', '1x USB 3.1 Gen 2, 3x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',36,31.99,104.99,'Fair',33 ), (Null,'MSI B250M GAMING PRO ','ATX',' Intel® 2066','1151','DDR4','5 x PCIe 3.0/2.0 x16,4 x USB 3.1 Gen1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',12,15.99,89.99,'Fair',17), (Null,'ASUS STRIX Z270H GAMING ','ATX','Intel® 2066','1151','DDR4','5 x PCIe 3.0/2.0 x16,4 x USB 3.1 Gen1, 4x USB 2.0', '2x USB 3.1 Gen 2, 2x USB 2.0','6 x SATA 6Gb/s', 'Zavisno od procesora',42,47.99,239.99,'Very Good',10);";
            runQuery(q6);
            databaseConnection.Close();

            string q7 = "INSERT INTO GraphicCards(GraphicCardID,Brand,Model,TypeOfRAM,RAM,Connectors,Cooling,Speed,Directx,Slot,Warranty,Profit,Price,Rating,Quantity) VALUES (Null,'Nvidia','GeForce M-NGT710/3R8LHDLP','GDDR3','2GB','1x VGA, 1x HDMI, 1x DVI-D', 'Passive',' 954Mhz','DirectX 12, OpenGL4.5','PCI Express 2.0',36,21.59,62.99,'Good',45), (Null,'Nvidia','GeForce M-NGTX1050/5R8HDP','GDDR5','2GB',' 1x Display Port, 1x HDMI, 1x DVI-D', 'Active','1379/1493MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',42,49.32,189.99,'Excellent',32), (Null,'Nvidia','GeForce GT 1030 ','GDDR5','2GB','1x DVI, 1x HDMI', 'Pasivno','1518 MHz / 1265 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',36,29.99,87.33,'Fair',16), (Null,'ATI Radeon ','Radeon R7 ','GDDR3','4GB','1x DVI, 1x HDMI', 'Active','1518 MHz / 1265 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',48,32.99,109.33,'Good',11), (Null,'Nvidia','GeForce GT 1030 Phoenix','GDDR5','2GB','1x DVI, 1x HDMI', 'Active','1399 MHz / 1889 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',48,45.99,132.33,'Good',4), (Null,'ATI Radeon','Radeon RX 560','GDDR5','4GB','1x DVI, 1x HDMI', 'Active','1199 MHz / 1779 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',36,41.99,162.33,'Excellent',18), (Null,'Nvidia','GeForce GTX 1050 ','GDDR5','2GB','1x DVI, 1x HDMI', 'Passive','1199 MHz / 1779 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',42,56.99,199.33,'Excellent',8), (Null,'ATI Radeon','Radeon RX 560 ','GDDR5','4GB','2x DVI, 2x HDMI', 'Active','1199 MHz / 1779 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',42,49.39,209.33,'Excellent',9), (Null,'Nvidia','GeForce GT 1030 ','GDDR5','2GB','2x DVI, 1x HDMI', 'Passive','1106 MHz/ Base: 1252 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',24,31.39,109.49,'Excellent',17), (Null,'Nvidia ','GeForce GTX 1050Ti G1 Gaming ','GDDR5','4GB','1x DVI, 3x HDMI', 'Active','1346 MHz/ Base: 1752 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',36,64.39,299.99,'Excellent',5), (Null,'ATI Radeon','Radeon RX 550 ','GDDR5','2GB','2x DVI, 3x HDMI', 'Active','1506 MHz/ Base: 1752 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',36,39.89,154.99,'Good',15), (Null,'ATI Radeon','Radeon RX 560 ','GDDR5','2GB','2x DVI, 3x HDMI', 'Passive','1226/1300MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',42,59.89,168.99,'Excellent',3), (Null,'ATI Radeon','Radeon RX 550 ','GDDR5','4GB','1x DVI, 1x HDMI', 'Passive',' 1500 MHz','DirectX 12, OpenGL4.5','PCI Express 3.0',42,59.89,175.99,'Excellent',10), (Null,'ATI Radeon','Radeon RX 560 ','GDDR5','4GB','2x DVI, 3x HDMI', 'Active','1300 MHz Boost Engine Clock','DirectX 12, OpenGL5.5','PCI Express 3.0',36,76.89,198.99,'Excellent',13), (Null,'Nvidia','GeForce GTX 1050 ','GDDR5','4GB','2x DVI, 3x HDMI', 'Active','1300 MHz Boost Engine Clock','DirectX 12, OpenGL5.5','PCI Express 3.0',48,69.99,229.99,'Excellent',23), (Null,'Nvidia','GeForce GTXi 1050 ','GDDR5','4GB','2x DVI, 3x HDMI', 'Active','1455 MHz / 1341 MHz','DirectX 12, OpenGL5.5','PCI Express 3.0',48,79.99,288.99,'Excellent',3), (Null,'Nvidia ','GTX 1050Ti ','GDDR5','4GB','2x DVI, 3x HDMI', 'Passive',' 1455 MHz / 1341 MHz','DirectX 12, OpenGL5.5','PCI Express 3.0',48,39.99,234.99,'Excellent',19), (Null,'Nvidia ',' RX 560 Gaming ','GDDR5','2GB','2x DVI, 3x HDMI', 'Passive',' 1455 MHz / 1341 MHz','DirectX 12, OpenGL5.5','PCI Express 3.0',48,54.99,248.99,'Excellent',14), (Null,'ATI Radeon',' Cerberus OC ','GDDR5','4GB','2x DVI, 3x HDMI', 'Passive',' 7008 MHz','DirectX 12, OpenGL5.5','PCI Express 3.0',36,51.99,258.99,'Excellent',4), (Null,'ATI Radeon',' RX 560 OC ','GDDR5','2GB','1x DVI, 3x HDMI', 'Passive',' 1455 MHz / 1341 MHz','DirectX 12, OpenGL5.5','PCI Express 3.0',48,34.99,148.99,'Good',6), (Null,'Nvidia ','GeForce GTX 1050 Phoenix ','GDDR5','2GB','2x DVI, 3x HDMI', 'Passive',' 1455 MHz / 1341 MHz','DirectX 12, OpenGL5.5','PCI Express 3.0',48,24.99,108.99,'Excellent',20);";
            runQuery(q7);
            databaseConnection.Close();

            string q8 = "INSERT INTO HardDisks(HardDiskID,Brand,Type,Model,Capacity,SpeedWR,Profit,Price,Quantity,Rating) VALUES (NULL,'WD','SSD','SSD M.2','500GB','Reading: 560 MB/s, Writting 530MB/s',34.99,154.99,98,'Very Good'), (NULL,'Kingston','SSD','Kingston KC400','256GB','550/540MB/s',27.99,147.99,120,'Very Good'), (NULL,'WD','HDD','WD BLUE 2.5','1TB','560 mb/s',30,204.99,50,'Excellent'), (NULL,'APACER','SSD','Panther','120G GB','560 mb/s',10.99,56.99,25,'Fair'), (NULL,'ADATA','SSD','Ultimate SU800 ','128G GB','560 mb/s',8.99,63.99,40,'Good'), (NULL,'TRANSCEND','SSD','SSD230 Series ','256G GB','560 mb/s',33.99,99.99,15,' Very Good'), (NULL,'TRANSCEND ','SSD','SSD370S Series','128G GB','560 mb/s',17.99,89.99,40,'Good'), (NULL,'KINGSTON','SSD','UV400 Series','240 GB','500 mb/s',23.99,110.18,20,'Good'), (NULL,'ADATA','SSD','Ultimate SU800 ','256 GB','560 mb/s',23.99,112.99,13,'Very Good'), (NULL,'WD ','SSD','WDS250G1B0A 2.5 ','250 GB','540 mb/s',31.99,123.99,40,'Very Good'), (NULL,'TOSHIBA ','HDD','SATA III ','500 GB','7200 rpm',13.99,53.99,4,'Good'), (NULL,'WD ','HDD','Caviar Red - WD10EFRX','1 Tb','7200 rpm',23.99,75.99,12,'Good'), (NULL,'SEAGATE ','HDD',' Iron Wolf NAS - ST1000VN002 ','1 Tb','5900 rpm',33.99,89.99,12,'Good'), (NULL,'SEAGATE ','HDD','BarraCuda Compute','3 TB','7200 rpm',41.99,139.99,19,'Very Good'), (NULL,'SEAGATE ','HDD','Barracuda - ST3000LM024 I ','3TB','7200 rpm',17.99,103.99,14,'Good'), (NULL,'SEAGATE ','HDD',' Iron Wolf NAS - ST6000VN004','6TB','7200 rpm',56.99,243.99,7,'Excellent'), (NULL,'SEAGATE','HDD','IronWolf NAS - ST8000VN0022 ','8 tB','7200 rpm',83.99,322.99,20,'Excellent'), (NULL,'WD ','HDD','Red Pro - WD8001FFWX ','8TB','7200 rpm',91.99,373.99,8,'Excellent'), (NULL,'ADATA','SSD','NVMe PCIe Gen3x4 ','1TB','1750 mb/s',120.99,453.99,15,'Excellent'), (NULL,'SAMSUNG ','SSD','Pro Series - MZ-7KE1T0BW ','1TB','550 mb/s',94.99,559.99,27,'Excellent'), (NULL,'WD ','SSD','WDS500G2B0B ','500 GB','560 mb/s',56.99,183.99,23,'Good');";
            runQuery(q8);
            databaseConnection.Close();

            string q9 = "INSERT INTO Ram(RamID,Brand,Type,Model,Capacity,Speed,Warranty,Profit,Price,Rating,Quantity)VALUES( NULL,'Kingston','DDR3','HyperX Fury Blue CL9, HX313C9F/4','4GB','1333MHz',36,23.70,59.99,'Good',26),( NULL,'Bulk','DDR3','OEM','8GB','1333MHz',42,15.99,74.99,'Very Good',19),( NULL,'Corsair Vengeance','DDR3','CMK16GX4M2A2666C16R','16GB(2x8GB)','2666MHz',54,40.99,280.99,'Excellent',8),( NULL,'Transcend','DDR4','JM2400HLB-8G','8GB','2400MHz',60,13.99,89.99,'Excellent',18),( NULL,'Transcend','DDR2','JM800QLU-1G','1GB','800MHz',36,2.99,22.99,'Poor',10),( NULL,'Kingston','DDR3','KVR13N9S6/2','8GB','1333MHz',120,8.00,32.99,'Fair',15),( NULL,'Kingston','DDR3','KCP313ND8/8','8GB','1333MHz',36,20.99,110.00,'Good',19),( NULL,'Kingston','DDR3','KCP316ND8/8','8GB','1600MHz',120,12.99,95.00,'Good',20),( NULL,'Kingston','DDR4','HX421C14FB2/8','8GB','2133MHz',120,13.99,100,'Very Good',30),( NULL,'Samsung','DDR4','CL15','8GB','2133MHz',36,19.99,110.99,'Good',3),( NULL,'Kingston','DDR4','KVR24N17D8/16','16GB','2400MHz',120,32.99,210.99,'Excellent',13),( NULL,'Kingston','DDR4','HX426C16FB/16','16GB','2666MHz',36,36.99,240.00,'Excellent',15),( NULL,'Corsair Vengeance','DDR4','GAFR416GB3000C16ADC','2x8GB','3000MHz',60,39.99,270.00,'Excellent',10),( NULL,'Corsair Vengeance','DDR4','CMK16GX4M2B3000C15R','8GB','3000MHz',60,33.99,280.00,'Excellent',3),( NULL,'Kingston','DDR4','HX426C16FBK2/32','32GB','2666MHz',36,80.99,440.00,'Excellent',4),( NULL,'Kingston','DDR4','CL15,HX430C15PB3K2/32','32GB','3000MHz',36,94.99,520.99,'Excellent',2),( NULL,'Kingston','DDR3',',KCP313ND8/8','8GB','1333MHz',36,9.99,100.20,'Good',17),( NULL,'Kingston','DDR4','KVR24N17S8/8','8GB','2400MHz',36,12.99,110.00,'Good',19),( NULL,'Kingston','DDR3','KCP316SD8/8','8GB','1600MHz',36,11.99,99.99,'Good',13),( NULL,'Kingston','DDR3','KCP3L16SD8/8','8GB','1600MHz',36,9.99,90.00,'Good',22);";
            runQuery(q9);
            databaseConnection.Close();

            string q10 = "INSERT INTO BRANCHES(BranchID,Name,Country,City,EmployeesID)VALUES (NULL,'GamingCentar NS1','Serbia','Novi Sad',2), (NULL,'GamingCentar W1','Austria','Wien',3), (NULL,'GamingCentar BG1','Serbia','Beograd',11), (NULL,'GamingCentar NI1','Serbia','Nis',8), (NULL,'GamingCentar TI1','Romania','Timisora',19), (NULL,'GamingCentar BD1','Hungary','Budapest',4), (NULL,'GamingCenter ZG1','Croatia','Zagreb',5), (NULL,'GamingCentar NS2','Serbia','Novi Sad',12), (NULL,'GamingCentar W2','Austria','Wien',13), (NULL,'GamingCentar BG2','Serbia','Beograd',10), (NULL,'GamingCentar NIS2','Serbia','Nis',18), (NULL,'GamingCentar TM2','Romania','Timisoara',9), (NULL,'GamingCentar BD2','Hungary','Budapest',6), (NULL,'GamingCenter ZG2','Croatia','Zagreb',7), (NULL,'GamingCenter ZG3','Croatia','Zagreb',14), (NULL,'GamingCentar TM3','Romania','Timisoara',16), (NULL,'GamingCentar BD3','Hungary','Budapest',15), (NULL,'GamingCentar NIS3','Serbia','Nis',17), (NULL,'GamingCentar NS3','Serbia','Novi Sad',1), (NULL,'GamingCentar W3','Austria','Wien',20);";
            runQuery(q10);
            databaseConnection.Close();

            string q11 = "INSERT INTO LAPTOP(LaptopID,Brand,GraphicCard,Processor,RAM,HardDisk,Quantity,Profit,Price,Rating) VALUES ( NULL,'Acer A315','Radeon 520 2GB','AMD DC A6-9220','4GB DDR3','1TB',10,75.00,425.00,'Good'), (NULL,'HP Pavilion G6','Radeon 6400M','Intel I5-2460M','6GB DDR3','750GB',5,60.00,310.00,'Fair'), (NULL,'Asus UX360CA','Intel HD Graphics','Intel Core M3-7Y30','4GB SO-DIMM DDR3L','128GB SSD',15,90.00,950.00,'Excellent'), (NULL,'Acer Aspire A315-41-R84R, NX.GY9EX.030','Radeon™ Vega 8 Integrated Graphics, 1100 MHz', 'AMD Ryzen™ 5 2500U, 2-3.6 GHz, sa 2 MB keš memorije, 4 cores, 8 threads', '4 GB DDR4 2400 MHz, 2 memorijska slota','500GB 2.5 inch 5400rpm HDD',8,79.00,590.00,'Good'), (NULL,'Acer Predator G3-572-50FE','NVIDIA® GeForce® GTX 1060 6 GB GDDR5', 'Intel® Core™ i5-7300HQ Processor, 2.5-3.5GHz, 6 MB cache, 4 cores, 8 threads, Intel® HM175', '8GB SO-DIMM DDR4, 2400MHz','1 TB HDD, 256 GB SSD',3,169.00,1453.99,'Excellent'), (NULL,'Lenovo ThinkPad T470','Intel® HD Graphics 620', 'Intel® Core™ i7-7500U, 2.70 GHz - 3.50 GHz, 4 MB SmartCache, 2 cores, 4 threads', '8GB DDR4,','256 GB SSD',2,189.00,1999.99,'Excellent'), (NULL,' HP ProBook 450 G5 ','NVIDIA® GeForce® 930MX 2 GB DDR3', 'Intel® Core™ i7-8550U Processor, 1.8-4.0 Ghz, 8 MB cache, 4 cores, 8 threads', '8 GB DDR4-2400 SDRAM ','1 TB 5400 rpm',19,99.00,799.99,'Good'), (NULL,'Asus UX410UA-GV097T ','Intel® HD graphics 620', 'Intel® Core™ i3-7100U Processor, 2.4GHz 3Mb cache, 2 cores, 4 threads', 'DDR4 4GB','256GB SSD',14,69.00,839.99,'Good'), (NULL,'Lenovo V330','I AMD Radeon 530 2GB GDDR5', 'Intel® Core™ i3-7100U Processor, 2.70GHz 3Mb cache, 2 cores, 4 threads', '4GB DDR4,2400MHz','128GB SSD',21,53.50,579.99,'Good'), (NULL,'HP Probook 450 G4','Intel® HD Graphics 620', 'Intel® Core™ i5-7200U Processor, 2.5-3.1 GHz, 2.70GHz 3Mb cache, 2 cores, 4 threads', '8 GB DDR4','1TB 5400 rpm',28,58.08,739.99,'Good'), (NULL,'Lenovo IdeaPad 320S-14','Intel HD Graphics 610', 'Intel® Core™ i3-7100U, 2.40 GHz, 3Mb cache, 2 cores, 4 threads', '4GB DDR4,','128GB SSD',18,42.08,519.99,'Fair'), (NULL,'DELL Inspiron 15 7000 Series 7577 ','nVidia GeForce® GTX 1050 4 Gb', 'Intel® Core™ i5 2.5 GHz (3.5 GHz) 6MB cache', '8GB DDR4 ','1 TB',11,114.98,1199.99,'Excellent'), (NULL,'Toshiba Tecra X40-D-10H ','Intel HD 620 ', 'Intel Core i7 Dual Core Processor 7500U 2.7GHz Turbo 3.5GHz 4 MB cache', '16GB DDR4 ','512 GB',31,204.98,2229.99,'Excellent'), (NULL,'Njoy Aerial (NOT12002)','Intel HD Graphics 500', 'Intel® Celeron® 1.1GHz Turbo 2.4GHz 2 MB cache', '4GB ','32GB eMMc',24,29.99,339.99,'Poor'), (NULL,'HP 15-bs106nm','Intel HD 500', 'Intel® Core™ i3 Dual Core Processor 5005U', '4GB ','1TB',17,55.99,599.99,'Good'), (NULL,'DELL Vostro 3568','Intel HD 520', 'Intel® Core™ i3 Dual Core Processor 5005U', '4GB ','1TB',37,53.99,489.99,'Good'), (NULL,'HP Pavilion ','Intel HD 620', 'Intel® Core™ i3 Dual Core Processor 2700mhz', '4GB ','500GB',23,68.99,604.99,'Good'), (NULL,'LENOVO IdeaPad 320-','AMD Radeon 530', 'Intel® Core™ i5 Dual Core Processor 7200', '8 GB ','1024GB',13,43.99,354.99,'Good'), (NULL,'TOSHIBA Portege A30','Intel HD 520', 'Intel® Core™ i5 6200U 2.8GHz', '8 GB ','500GB',13,43.99,354.99,'Good'), (NULL,'APPLE MacBook Air 13','Intel HD 6000', 'Intel® Core™ i5 5350U ', '8 GB ','256GB SSD',14,87.99,950.99,'Excellent');";
            runQuery(q11);
            databaseConnection.Close();

            string q12 = "INSERT INTO Processors(ProcessorID,Name,Brand,Slot,WorkingTact,Cache,Cores,Threads,Warranty,Profit,Price,Quantity,Rating) VALUES( NULL,'Intel I5-4460','Intel','1150','3.2GHz','6MB L3','2','4',36,50.99,189.99,33,'Very Good'),( NULL,'AM4 AMD A10-9700','AMD','AM4','3.5GHz','L2 Cache Size 2MB','4','4',24,42.99,109.99,28,'Fair'),( NULL,'CPU AM3+ AMD FX-4320','AMD','4.0GHz','2x2MB L2','4MB L3','2','2',24,23.99,50.90,71,'Poor'),( NULL,'Intel I7-7820X','Intel','FCLGA2006','3.60GHz','11 MB L3','8','16',24,72.80,580.00,15,'Excellent'),( NULL,'Intel Core i7-8700','Intel','1151','4.6GHz','6 x 256 KB','6','12',36,43.99,350.00,10,'Very Good'),( NULL,'CPU FM2+ AMD Athlon','AMD','FM 2+','3.1GHz','4MB L2','4','8',24,11.99,52.99,28,'Good'),( NULL,'APU AM4 AMD A12-9800','AMD','AM4','3.8GHz','L2 Cache: 2MB','4','8',36,15.99,105.99,20,'Very Good'),( NULL,'AM4 AMD Ryzen 5 2600X','AMD','AM4','3.6GHz','(L2+L3) 19MB','6','12',24,29.99,230.00,12,'Excellent'),( NULL,'Intel I5-7600K','Intel','LGA1151','3.8GHz','6MB','8','12',36,39.99,264.99,11,'Excellent'),( NULL,'Intel I5-6600K','Intel','1151','3.5GHz','6MB','8','12',36,26.99,195.00,22,'Very Good'),( NULL,'Intel I7-7700','Intel','LGA1151','3.6GHz','8MB','8','12',36,39.99,310.00,5,'Excellent'),( NULL,'Intel I5-8600','Intel','1151','3.1GHz','L2 keš memorija 6x 256KB, L3 keš memorija 9MB.','4','6',36,27.99,265.99,12,'Excellent'),( NULL,'Intel I5-8600K','Intel','1151','3.6GHz','L2 keš memorija 6x 256KB, L3 keš memorija 9MB.','4','6',36,37.99,304.99,8,'Excellent'),( NULL,'AM4 AMD Ryzen 7 1700X','AMD','AM4','3.8GHz','16MB','8','16',36,44.99,400.99,6,'Excellent'),( NULL,'Intel I3-7100','Intel','LGA1151','3.9GHz','3MB','4','8',24,20.99,132.99,30,'Very Good'),( NULL,'Intel I3-8100','Intel','1151','3.6GHz','L2 keš memorija 4x 256KB, L3 keš memorija 6MB.','4','4',24,15.99,112.99,30,'Good'),( NULL,'AM4 AMD Ryzen 3 2200G','AMD','AM4','3.4Ghz','L3 Cache 4MB','4','4',36,19.99,122.99,15,'Good'),( NULL,'AM4 AMD A12-9800E','AMD','AM4','3.4Ghz','L2 Cache 2MB','4','4',36,11.99,103.99,30,'Excellent'),( NULL,'Athlon X4 Quad-Core 840','AMD','FM2+','3.4Ghz','4MB L2','4','4',24,7.99,49.99,43,'Poor'),( NULL,'Athlon A8-9600','AMD','AM4','3.4Ghz','L2 Cache 2MB','4','4',36,9.99,65.99,32,'Fair');";
            runQuery(q12);
            databaseConnection.Close();

            string q13 = "INSERT INTO ORDERS(OrderID,OrderDate,Status,Payment,CustomerID,EmployeesID)VALUES (Null,20180206,'Approved','Master-Card',2,3), (Null,20170215,'Approved','Master-Card',5,3), (Null,20180119,'Approved','Visa-Card',7,13), (Null,20170321,'Active','Dina-Card',4,11), (NULL,20170803,'Approved','Visa-Card',6,11), (Null,20170929,'Approved','Master-Card',2,10), (Null,20180211,'Approved','Visa-Card',2,3), (Null,20180228,'Approved','Dina-Card',4,1), (Null,20160617,'Approved','Master-Card',7,9), (Null,20170126,'Approved','Visa-Card',18,11), (Null,20180420,'Active','Dina-Card',13,12), (Null,20171223,'Approved','Master-Card',10,3), (Null,20180416,'Approved','Visa-Card',1,4), (Null,20170816,'Approved','Dina-Card',16,11), (Null,20180422,'Approved','Master-Card',8,17), (Null,20180313,'Approved','Master-Card',14,7), (Null,20170818,'Approved','Visa-Card',11,10), (Null,20171105,'Approved','Master-Card',6,9), (Null,20180116,'Approved','Visa-Card',11,1), (Null,20180512,'Active','Dina-Card',20,20)";
            runQuery(q13);
            databaseConnection.Close();

            string q14 = "INSERT INTO ORDERDETAILS(OrderDetID,CustomerID,EmployeesID,LaptopID,GameID,ConsoleID,OrderID,PCPeripheralID,MotherBoardID,GraphicCardID, ProcessorID,HardDiskID,RamID,QuantityOrdered,PriceTotal) VALUES (Null,2,3,Null,Null,Null,1,Null,2,1,Null,1,Null,3,215.98), (Null,5,3,Null,Null,Null,2,Null,7,Null,Null,Null,Null,1,89.99), (Null,7,13,Null,Null,Null,3,Null,Null,Null,20,Null,7,2,176.98), (Null,4,11,Null,13,Null,4,Null,Null,Null,Null,Null,9,3,140.99), (Null,6,11,Null,5,Null,5,Null,Null,2,Null,Null,Null,2,254.98), (Null,2,10,Null,5,18,6,Null,Null,Null,Null,Null,Null,2,434.98), (Null,2,3,Null,13,Null,7,Null,Null,6,Null,Null,9,3,303.32), (Null,4,1,Null,Null,Null,8,Null,10,Null,20,9,1,4,288.96), (Null,7,9,11,13,Null,9,11,Null,Null,Null,6,Null,4,720.96), (Null,18,11,18,3,Null,10,Null,Null,Null,20,Null,19,4,1022.96), (Null,13,12,Null,4,Null,11,Null,Null,Null,20,Null,Null,3,210.97), (Null,10,3,Null,Null,Null,12,19,11,10,Null,Null,Null,3,519.97), (Null,1,4,Null,Null,17,13,Null,Null,Null,Null,7,8,3,226.98), (Null,16,11,6,13,Null,14,6,Null,Null,Null,20,Null,4,2709.97), (Null,8,17,Null,9,3,15,Null,Null,Null,Null,Null,Null,2,369.99), (Null,14,7,Null,5,12,16,5,Null,Null,Null,Null,17,4,408.17), (Null,11,10,Null,Null,Null,17,Null,14,15,6,Null,Null,3,402.97), (Null,6,9,16,18,Null,18,16,Null,Null,Null,9,10,5,775.99), (Null,11,1,Null,6,3,19,Null,16,Null,Null,Null,Null,3,498.97), (Null,20,20,Null,8,3,20,Null,Null,Null,Null,6,17,4,525.98);";
            runQuery(q14);
            databaseConnection.Close();
        }

        public void runQuery(string query1)
        {

            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();

            myReader = commandDatabase.ExecuteReader();
        }

        private string GetResult(MySqlDataReader rd)
        {
            
            if (rd.HasRows)
            {
                MessageBox.Show("Your query generated results");
                StringBuilder rezultat = new StringBuilder();

                while (rd.Read())
                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        try
                        {
                            rezultat.Append(myReader.GetString(i));
                            rezultat.Append(" ");
                        }
                        catch (System.Data.SqlTypes.SqlNullValueException)
                        {
                            rezultat.Append("NULL");
                            rezultat.Append(" ");
                        }
                        

                    }
                    rezultat.Append("\n");

                }
                return rezultat.ToString();
            }
            
            
            
            return null;
        }

        
        static string q1 = "SELECT Employees.Name,Employees.LastName,MONTH(Orders.OrderDate),SUM(PriceTotal),Branches.Name FROM Employees,OrderDetails,Orders,Branches WHERE Branches.EmployeesID = Employees.EmployeesID AND Orders.OrderDate >='20180201' and Orders.OrderDate <= '20180301' AND OrderDetails.OrderID = Orders.OrderID AND OrderDetails.EmployeesID = Employees.EmployeesID AND Orders.EmployeesID = Employees.EmployeesID GROUP BY Employees.Name ORDER BY OrderDetails.PriceTotal DESC;";
        static string q2 = "SELECT Games.Name,Games.Profit,COUNT(OrderDetails.OrderID) FROM Games,OrderDetails,Orders WHERE OrderDetails.GameID = Games.GameID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY Games.Profit DESC UNION SELECT Laptop.Brand,Laptop.Profit,COUNT(OrderDetails.OrderID) FROM Laptop,OrderDetails,Orders WHERE OrderDetails.LaptopID = Laptop.LaptopID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY Laptop.Profit DESC UNION SELECT GraphicCards.Brand,GraphicCards.Profit,COUNT(OrderDetails.OrderID)FROM GraphicCards,OrderDetails,Orders WHERE OrderDetails.GraphicCardID = GraphicCards.GraphicCardID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY GraphicCards.Profit DESC UNION SELECT HardDisks.Brand,Harddisks.Profit,COUNT(OrderDetails.OrderID) FROM HardDisks,OrderDetails,Orders WHERE OrderDetails.HardDiskID = HardDisks.HardDiskID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY HardDisks.Profit DESC UNION SELECT MotherBoards.Model,MotherBoards.Profit,COUNT(OrderDetails.OrderID) FROM MotherBoards,OrderDetails,Orders WHERE OrderDetails.MotherBoardID = MotherBoards.MotherBoardID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY MotherBoards.Profit DESC UNION SELECT PCPeripheral.Category,PCPeripheral.Profit,COUNT(OrderDetails.OrderID) FROM PCPeripheral,OrderDetails,Orders WHERE OrderDetails.PCPeripheralID = PCPeripheral.PCPeripheralID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY PCPeripheral.Profit DESC UNION SELECT Processors.Brand,Processors.Profit,COUNT(OrderDetails.OrderID) FROM Processors,OrderDetails,Orders WHERE OrderDetails.ProcessorID = Processors.ProcessorID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY Processors.Profit DESC UNION SELECT Ram.Brand,Ram.Profit,COUNT(OrderDetails.OrderID) FROM Ram,OrderDetails,Orders WHERE OrderDetails.RamID = Ram.RamID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY Ram.Profit DESC UNION SELECT Console.Name,Console.Profit,COUNT(OrderDetails.OrderID) FROM Console,OrderDetails,Orders WHERE OrderDetails.ConsoleID = Console.ConsoleID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' and Orders.OrderDate <= '20180601' GROUP BY Console.Profit DESC;";
        static string q3 = "(SELECT GraphicCards.Brand,GraphicCards.Model FROM GraphicCards,Orders,OrderDetails WHERE OrderDetails.GraphicCardID = GraphicCards.GraphicCardID AND OrderDetails.OrderID = Orders.OrderID GROUP BY GraphicCards.GraphicCardID ORDER BY (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate) = 2017) THEN GraphicCards.Profit ELSE null END))- (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate = 2018)) THEN GraphicCards.Profit ELSE null END)) LIMIT 1) UNION (SELECT Processors.Brand,Name FROM Processors,Orders,OrderDetails WHERE OrderDetails.ProcessorID = Processors.ProcessorID AND OrderDetails.OrderID = Orders.OrderID GROUP BY Processors.ProcessorID ORDER BY (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate) = 2017) THEN Processors.Profit ELSE null END))- (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate = 2018)) THEN Processors.Profit ELSE null END)) LIMIT 1) UNION (SELECT Ram.Brand,Ram.Capacity FROM Ram,Orders,OrderDetails WHERE OrderDetails.RamID = Ram.RamID AND OrderDetails.OrderID = Orders.OrderID GROUP BY Ram.RamID ORDER BY (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate) = 2017) THEN Ram.Profit ELSE null END))- (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate = 2018)) THEN Ram.Profit ELSE null END)) LIMIT 1) UNION (SELECT HardDisks.Brand,HardDisks.Type FROM HardDisks,Orders,OrderDetails WHERE OrderDetails.HardDiskID = HardDisks.HardDiskID AND OrderDetails.OrderID = Orders.OrderID GROUP BY HardDisks.HardDiskID ORDER BY (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate) = 2017) THEN HardDisks.Profit ELSE null END))- (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate = 2018)) THEN HardDisks.Profit ELSE null END)) LIMIT 1) UNION (SELECT MotherBoards.Model,Chipset FROM MotherBoards,Orders,OrderDetails WHERE OrderDetails.MotherBoardID = MotherBoards.MotherBoardID AND OrderDetails.OrderID = Orders.OrderID GROUP BY MotherBoards.MotherBoardID ORDER BY (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate) = 2017) THEN MotherBoards.Profit ELSE null END))- (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate = 2018)) THEN MotherBoards.Profit ELSE null END)) LIMIT 1) ";
        static string q4 = "SELECT Games.Name FROM OrderDetails,Customers,Games WHERE OrderDetails.GameID = Games.GameID AND OrderDetails.CustomerID = Customers.CustomerID AND Customers.BirthDate < '19971231' GROUP BY Games.Name ORDER BY OrderDetails.OrderID LIMIT 1;";
        static string q5 = "SELECT Branches.Name,SUM(OrderDetails.PriceTotal) FROM OrderDetails,Branches,Employees,Orders WHERE OrderDetails.EmployeesID = Employees.EmployeesID AND OrderDetails.EmployeesID = Branches.EmployeesID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180101' and Orders.OrderDate <= '20180601' GROUP BY Branches.Name ORDER BY PriceTotal LIMIT 1;";
        static string q6 = "SELECT Branches.Name,Branches.Country,SUM(OrderDetails.PriceTotal) FROM Branches,OrderDetails,Orders,Employees WHERE OrderDetails.EmployeesID = Employees.EmployeesID AND OrderDetails.EmployeesID = Branches.EmployeesID AND OrderDetails.OrderID = Orders.OrderID GROUP BY Branches.Name ORDER BY SUM(OrderDetails.PriceTotal) LIMIT 1;";
        static string q7 = "(SELECT Games.Type, Games.Name, Games.Genre FROM Games,OrderDetails,Orders WHERE Games.Type = 'PC-Game' AND Games.Genre = 'Action' AND OrderDetails.GameID = Games.GameID AND OrderDetails.OrderID = Orders.OrderID GROUP BY Games.Name DESC LIMIT 1) UNION (SELECT Games.Type, Games.Name,Games.Genre FROM Games,OrderDetails,Orders WHERE Games.Type = 'Console-Game' AND Games.Genre = 'Sport' AND OrderDetails.GameID = Games.GameID AND OrderDetails.OrderID = Orders.OrderID GROUP BY Games.Name ASC LIMIT 1);";
        static string q8 = "(SELECT MAX(Customers.City),COUNT(OrderDetails.CustomerID) FROM Customers,OrderDetails,Orders WHERE OrderDetails.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND Orders.CustomerID = Customers.CustomerID GROUP BY Customers.City ORDER BY OrderDetails.CustomerID ASC LIMIT 1) UNION (SELECT MIN(Customers.City),COUNT(OrderDetails.CustomerID) FROM Customers,OrderDetails,Orders WHERE OrderDetails.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND Orders.CustomerID = Customers.CustomerID GROUP BY Customers.City ORDER BY OrderDetails.CustomerID DESC LIMIT 1);";
        static string q9 = "SELECT Harddisks.Brand,Type,Capacity,SUM(HardDisks.Profit) FROM HardDisks,OrderDetails,Orders WHERE HardDisks.Type = 'SSD' AND OrderDetails.HardDiskID = HardDisks.HardDiskID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180101' and Orders.OrderDate < '20180601' GROUP BY HardDisks.Profit DESC";
        static string q10 = "SELECT Laptop.Brand FROM Laptop,Orders,OrderDetails WHERE OrderDetails.LaptopID = Laptop.LaptopID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20160601' and Orders.OrderDate <= '20180601' GROUP BY Laptop.Brand ORDER BY 'Laptop' LIMIT 1";
        static string q11 = "SELECT MAX(Customers.Country),GraphicCards.Brand,GraphicCards.Model,Orders.OrderDate FROM Customers,OrderDetails,Orders,GraphicCards WHERE GraphicCards.Brand = 'Nvidia' AND OrderDetails.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20170101' and Orders.OrderDate < '20180701' GROUP BY Customers.Country ORDER BY OrderDetails.OrderID DESC LIMIT 1;";
        static string q12 = "SELECT Branches.Name,Branches.City,SUM(PriceTotal),MONTH(Orders.OrderDate) FROM Branches,OrderDetails,Orders,Employees WHERE Branches.City = 'Novi Sad' AND OrderDetails.EmployeesID = Employees.EmployeesID AND Orders.EmployeesID = Employees.EmployeesID AND Branches.EmployeesID = Employees.EmployeesID AND Orders.OrderDate >= '20180101' and Orders.OrderDate <= '20181231' GROUP BY Branches.Name;";
        static string q13 = "SELECT Processors.Name,COUNT(Processors.Name) FROM Processors,OrderDetails,Orders WHERE Processors.Cores = 4 AND OrderDetails.ProcessorID = Processors.ProcessorID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180101' AND Orders.OrderDate <= '20180601' ORDER BY Orders.OrderDate;";
        static string q14 = "SELECT Employees.Name,COUNT(OrderDetails.GameID) FROM Employees,OrderDetails,Games WHERE Games.Platform = 'PC' AND OrderDetails.EmployeesID = Employees.EmployeesID AND OrderDetails.GameID = Games.GameID GROUP BY Employees.Name LIMIT 1;";
        static string q15 = "SELECT Ram.Brand,Ram.Model,Ram.Capacity,SUM(Ram.Profit),COUNT(OrderDetails.RamID) FROM Ram,OrderDetails,Orders WHERE Ram.Capacity = '8GB' AND OrderDetails.RamID = Ram.RamID AND OrderDetails.OrderID = Orders.OrderID GROUP BY Ram.Profit Limit 1;";
        static string q16 = "SELECT AVG(YEAR(Customers.BirthDate)) FROM Customers,OrderDetails,Orders WHERE OrderDetails.CustomerID = Customers.CustomerID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180301' AND Orders.OrderDate <= '20180601'";
        static string q17 = "SELECT Console.Name,Orders.OrderDate,COUNT(OrderDetails.ConsoleID) FROM Console,Orders,OrderDetails WHERE OrderDetails.ConsoleID = Console.ConsoleID AND OrderDetails.OrderID = Orders.OrderID GROUP BY Console.ConsoleID ORDER BY (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate) = 2017) THEN Console.Profit ELSE null END)) - (SELECT AVG(CASE WHEN (SELECT EXTRACT(YEAR FROM Orders.OrderDate = 2018)) THEN Console.Profit ELSE null END)) LIMIT 3;";
        static string q18 = "SELECT Employees.Name,LastName,SUM(OrderDetails.PriceTotal),Branches.Name FROM Employees,MotherBoards,OrderDetails,Branches WHERE OrderDetails.EmployeesID = Employees.EmployeesID AND OrderDetails.MotherBoardID = MotherBoards.MotherBoardID AND Branches.EmployeesID = Employees.EmployeesID GROUP BY Employees.Name ORDER BY Branches.Name ASC;";
        static string q19 = "SELECT SUM(Ram.Profit) FROM Ram,OrderDetails,Orders WHERE OrderDetails.RamID = Ram.RamID AND OrderDetails.OrderID = Orders.OrderID AND Orders.OrderDate >= '20180101' and Orders.OrderDate <= '20180601';";
        static string q20 = "SELECT Employees.Name,LastName,Branches.Name,Branches.City FROM Employees,Branches,OrderDetails WHERE Employees.Rating = 5 AND Employees.EmployeesID = OrderDetails.EmployeesID AND Employees.EmployeesID = Branches.EmployeesID GROUP BY Employees.Name,Employees.LastName LIMIT 1;";

        public void button1_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    runQuery(q1);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 1:
                    runQuery(q2);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 2:
                    
                    runQuery(q3);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 3:
                   
                    runQuery(q4);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 4:
                    
                    runQuery(q5); 
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 5:
                    
                    runQuery(q6);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 6:
                    
                    runQuery(q7);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 7:
                    
                    runQuery(q8);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 8:

                    runQuery(q9);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 9:
                   
                    runQuery(q10);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 10:
                    
                    runQuery(q11);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 11:
                    
                    runQuery(q12);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 12:
                    
                    runQuery(q13);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 13:
                    
                    runQuery(q14);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 14:
                    runQuery(q15);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 15:
                    runQuery(q16);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;

                case 16:
                    
                    runQuery(q17);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 17:
                    
                    runQuery(q18);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 18:
                    
                    runQuery(q19);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                case 19:
                    runQuery(q20);
                    addToTb(GetResult(myReader));
                    databaseConnection.Close();
                    break;
                

            }
            
        }
       
        private void addToTb(string text)
        {
            textBox1.Text = text;
            textBox1.Text = text.Replace("\n", Environment.NewLine);

        }

        private void appendToTb(string text)
        {
            
            textBox1.Text += text + Environment.NewLine + Environment.NewLine;
            //textBox1.Text = text.Replace("\n", Environment.NewLine);
            




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public static string dtfordb(DateTime dt)
        {
            return dt.Year + "-" + dt.Month + "-" + dt.Day + " " + dt.TimeOfDay;
        }


        
        
        private void onloadCb()
        {
    
            comboBox1.Items.Add("1. Koji radnici su ostvarili najveci profit u februaru mesecu ove godine? Grupisani po poslovnicama");
            comboBox1.Items.Add("2. Na kojim proizvodima je najveća zarada u ovom kvartalu?");
            comboBox1.Items.Add("3. Koji hardverski proizvodi su imali najveci porast prodaje u 2017 a koji imaju za sad u 2018?");
            comboBox1.Items.Add("4. Koja je najpopularnija igrica trenutno za osobe preko 20 godine?");
            comboBox1.Items.Add("5. Koja poslovnica je ostvarila najveci profit u proteklih pola godine?");
            comboBox1.Items.Add("6. Koja poslovnica iz neke drzave je imala najmanju zaradu? Groupisano po minimalnom profitu");
            comboBox1.Items.Add("7. Koja je najprodavanija igrica za konzole ciji je zanr Sport, a koja za PC ciji je zanr Akcioni?");
            comboBox1.Items.Add("8. Iz kojih gradova ljudi kupuju najvise a iz kojih najmanje u proteklih 3 meseca?");
            comboBox1.Items.Add("9. Koji je profit od prodatih SSD diskova prethodna 2 kvartala?");
            comboBox1.Items.Add("10. Koji model nekog brenda laptopa se najbolje pokazao na trzistu u prethodne 2 godine");
            comboBox1.Items.Add("11. Iz koje drzave je bila najveca potraznja grafickih kartica Nvidia u 2017 godini?");
            comboBox1.Items.Add("12. U kom mesecu ove godine smo najvise zaradili iz poslovnica u Novom Sadu? I koliko smo narudzbina imali u toj poslovnici");
            comboBox1.Items.Add("13. Koji procesor sa 4 jezgra se najvise prodao izmedju 1 i 2 kvartala ove godine?");
            comboBox1.Items.Add("14. Koji prodavac je prodao najvise igrica za PC?");
            comboBox1.Items.Add("15. Prikaz najprodavanijeg modela RAM memorije od 8GB grupisanih po tipu, sortirani po profitu");
            comboBox1.Items.Add("16. Prikaz prosecne starosti kupaca koji su najvise kupovali u proteklih 3 meseca");
            comboBox1.Items.Add("17. Prikaz modela konzola sa najvecim rastom u prodaji o odnosu na 2017 godinu");
            comboBox1.Items.Add("18. Prikaz najefikasnijih prodavaca po broju prodatih maticinih ploca I po ukupnoj zaradi,grupisanih po zaradi");
            comboBox1.Items.Add("19. Koji je profit ostrvaren za RAM memoriju u poslednjih 6 meseci?");
            comboBox1.Items.Add("20. Koji radnik je najbolje ocenjen u nekoj od poslovnica");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to drop all the tables?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    string drop = "DROP TABLE Employees,Customers,Console,Laptop,GraphicCards,Games,MotherBoards,Ram,HardDisks,Processors,Branches,Orders,OrdeDetails,PcPeripheral";
                    MessageBox.Show("Success");
                    runQuery(drop);
                    databaseConnection.Close();
                    break;

            }
            
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            fillTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            createTables();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
