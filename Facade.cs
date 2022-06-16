using System;

namespace Facade
{
    public class HomeTheaterFacade    
    {
        DolbyDigital dolby; 
        CDPlayer cd = new CDPlayer();
        FMTuner radio = new FMTuner();    

        DVDPlayer dvd; 
        PlayStation ps;
        Projector prj = new Projector();    

        LightSession lumus = new LightSession();   
        LovingWife kiki;

        public void watchMovie()   
        {
            dvd = new DVDPlayer();
            dolby = new DolbyDigital();
            dvd.On(dolby);
            prj.On();

            dvd.ChooseLanguage();
            dvd.startMovie();
            lumus.dimming();

            kiki = new LovingWife();
            kiki.Beverage();
            kiki.Snacks();


            Console.WriteLine("\nДля регулировки громкости нажмите: +) Громче; -) Тише\n");
            var vol = Console.ReadLine();
            switch (vol)
            {
                case "+":
                    dolby.VolumeUP();
                    break;
                case "-":
                    dolby.VolumeDOWN();
                    break;
            }

        }

        public void endMovie()    
        {
            dvd.finishMovie();
            prj.Off();
            dvd.Off();
            lumus.off();
        }

        public void listenCD() 
        {
            cd = new CDPlayer();
            dolby = new DolbyDigital();
            cd.On(dolby);
            lumus.dimming();

            Console.WriteLine("\nДля регулировки громкости нажмите: +) Громче; -) Тише\n");
            var x = Console.ReadLine();
            switch (x)
            {
                case "+":
                    dolby.VolumeUP();
                    break;
                case "-":
                    dolby.VolumeDOWN();
                    break;
            }

            Console.WriteLine("\nЧтобы переключить композицию нажмите: +) Next; -) Previous\n");
            x = Console.ReadLine();
            switch (x)
            {
                case "+":
                    cd.Next();
                    break;
                case "-":
                    cd.Prev();
                    break;
            }
        }

        public void stopCD()  
        {
            cd.Off();
            dolby.Off();
            lumus.off();
        }

        public void listenRadio() 
        {
            dolby = new DolbyDigital();
            radio = new FMTuner();
            radio.On(dolby);
            radio.setFrequency();

            Console.WriteLine("\nДля регулировки громкости нажмите: +) Громче; -) Тише\n");
            var x = Console.ReadLine();
            switch (x)
            {
                case "+":
                    dolby.VolumeUP();
                    break;
                case "-":
                    dolby.VolumeDOWN();
                    break;
            }
            Console.WriteLine("\nУстановить таймер отключения? (1) Да; (0) Нет\n");
            x = Console.ReadLine();
            if (x == "1")
                radio.setSleepTimer();
        }

        public void noMoreRadio()
        {
            radio.Off();
        }

        public void runPlayStation()
        {
            dolby = new DolbyDigital();
            ps = new PlayStation();
            ps.On(dolby);
            lumus.gaming();

            kiki = new LovingWife();
            kiki.Beverage();
            kiki.Snacks();
            ps.ChooseGame();
            ps.ChooseComplexity();

            Console.WriteLine("\nДля регулировки громкости нажмите: +) Громче; -) Тише\n");
            var x = Console.ReadLine();
            switch (x)
            {
                case "+":
                    dolby.VolumeUP();
                    break;
                case "-":
                    dolby.VolumeDOWN();
                    break;
            }
        }

        public void exitPLayStation()
        {
            ps.byePS();
            dolby.Off();
            lumus.off();
            kiki.Free();
        }
    }

    public class DolbyDigital
    {
        public void On()
        {
            Console.WriteLine("\n5.1 Surround activated. Enjoy!");
        }

        public void Off()
        {
            Console.WriteLine("\nSound experience is over!");
        }

        public void VolumeUP()
        {
            Console.WriteLine("\nГромкость была увеличена!");
        }

        public void VolumeDOWN()
        {
            Console.WriteLine("\nВы уменьшили громкость.");
        }

    }

    public class FMTuner  
    {
        DolbyDigital dolby;

        public void On(DolbyDigital dolby)
        {
            this.dolby = dolby;
            Console.WriteLine("\nRadio is working. Voice Equalizer is on.");
            dolby.On();
        }

        public void Off()
        {
            Console.WriteLine("\nRadio turned off.");
            dolby.Off();
        }

        public void setFrequency()
        {
            Console.WriteLine("\nPlease, choose RadioStation(e.g. 88.00):\n");
            Console.WriteLine("\n" + Console.ReadLine() + " is playing now.");
        }

        public void setSleepTimer()
        {
            Console.WriteLine("\nSet sleep timer(minutes):\n");
            Console.WriteLine("\nIn " + Console.ReadLine() + " minutes radio will turn off.");
        }
    }

    public class DVDPlayer
    {
        private DolbyDigital dolby;

        public void On(DolbyDigital dolby)
        {
            this.dolby = dolby;
            Console.WriteLine("\nPlease, insert a DVD-disk.");
            dolby.On();
        }

        public void Off()
        {
            Console.WriteLine("Thank you for watching! You can take DVD disk out");
            dolby.Off();
        }

        public void ChooseLanguage()  
        {
            Console.WriteLine("Choose Audio Language:\n" +
                "1) Russian;\t2) English;\t3) French;\n");

            string idioma = Console.ReadLine();

            switch (idioma)
            {
                case "1":
                    idioma = "Russian";
                    break;
                case "2":
                    idioma = "English";
                    break;
                case "3":
                    idioma = "French";
                    break;
            }
            Console.WriteLine("\n" + idioma + " audioline is set");
        }

        public void startMovie()
        {
            Console.WriteLine("\nEnjoy a film!");
        }

        public void finishMovie()
        {
            Console.WriteLine("\nWow! What a film! Astonishing!");
        }

    }

    public class PlayStation
    {
        DolbyDigital dolby;

        public void On(DolbyDigital dolby)
        {
            this.dolby = dolby;
            dolby.On();
        }

        public void RunPS()
        {
            Console.WriteLine("\nOrigato, sensei! Connecting to PS Network.");
        }

        public void ChooseGame()
        {
            Console.WriteLine("\nВо что сегодня поиграем?\n1) FIFA 22;\t2)Assasin's Creed;\t3)GTA V;\t4)NFS;\n");
            string game = Console.ReadLine();

            switch (game)
            {
                case "1":
                    game = "FIFA 22";
                    break;
                case "2":
                    game = "Assasin's Creed";
                    break;
                case "3":
                    game = "GTA V";
                    break;
                case "4":
                    game = "NFS";
                    break;
            }
            Console.WriteLine("\n" + game + " is launching");
        }

        public void ChooseComplexity()
        {
            Console.WriteLine("\nВыбрать сложность: 1) EASY;\t2) MEDIUM;\t3) HARD;\t4) ULTRA HARD;\n");
            var x = Console.ReadLine();
            switch (x)
            {
                case "1":
                    Console.WriteLine("\nВы выбрали режим новичка.");
                    break;
                case "2":
                    Console.WriteLine("\nВы выбрали режим средней сложности.");
                    break;
                case "3":
                    Console.WriteLine("\nВы выбрали достойную сложность.");
                    break;
                case "4":
                    Console.WriteLine("\nВы выбрали самый сложный режим. Держитесь!");
                    break;
            }
        }

        public void byePS()
        {
            Console.WriteLine("\nОтличная была катка! Мы надрали им задницы!");
        }
    }

    public class CDPlayer
    {
        DolbyDigital dolby;
        public void On(DolbyDigital dolby)
        {
            this.dolby = dolby;
            Console.WriteLine("\nPlease, insert a CD-disk.");
            dolby.On();
        }

        public void Off()
        {
            Console.WriteLine("\nСеанс закончен. Выньте диск!");
        }
        public void Next()
        {
            Console.WriteLine("\nСледующий трэк");
        }

        public void Prev()
        {
            Console.WriteLine("\nПредыдущий трэк");
        }
    }

    public class Projector    
    {
        public void On()
        {
            Console.WriteLine("\nНастраиваю проекцию на стену.\n");
        }
        public void Off()
        {
            Console.WriteLine("\nПроектор выключается.\n");
        }
    }

    public class LightSession   
    {
        public void dimming()
        {
            Console.WriteLine("\nПриглушенный свет поможет Вам лучше погрузиться в атмосферу кино/музыки.");
        }
        public void gaming()
        {
            Console.WriteLine("\nЦветовая гамма будет меняться в зависимости от характера игры.");
        }
        public void off()
        {
            Console.WriteLine("\nПодсветка отключена.");
        }
    }

    public class LovingWife
    {
        public void Beverage()
        {
            Console.WriteLine("\nSweetheart, here are some bottles of beer for you! Enjoy it!");
        }

        public void Snacks()
        {
            Console.WriteLine("\n...And your favourite chips as well!");
        }

        public void Free()
        {
            Console.WriteLine("\nMy Love! I'm done. I'm fully yours!");
        }

    }

    class Program { 

        static void Main(string[] args)
        {
            var Client = new HomeTheaterFacade();

            Console.WriteLine("Добро пожаловать в мультимедийную систему EasyWay!!!");

            bool answer = false;
            while (!answer)
            {
                Console.WriteLine(
                                "\n\nВыберите команду:\n" +
                                "1) Watch Movie;\t " +
                                "2) End Movie;\t " +
                                "3) listen CD;\n" +
                                "4) stop CD;\t " +
                                "5) Turn on Radio;\t " +
                                "6) Turn off Radio;\n" +
                                "7) Run PlayStation 5;\t " +
                                "8) Exit Playstation 5\n" +
                                "9) Завершить Сеанс\n");

                var choice = Convert.ToInt32(Console.ReadLine()); 

                switch (choice)
                {
                    case 1:
                        Client.watchMovie();
                        break;
                    case 2:
                        Client.endMovie();
                        break;
                    case 3:
                        Client.listenCD();
                        break;
                    case 4:
                        Client.stopCD();
                        break;
                    case 5:
                        Client.listenRadio();
                        break;
                    case 6:
                        Client.noMoreRadio();
                        break;
                    case 7:
                        Client.runPlayStation();
                        break;
                    case 8:
                        Client.exitPLayStation();
                        break;
                    case 9:
                        Console.WriteLine("\nДо скорой встречи, Хозяин!");
                        answer = true;
                        break;
                }
            }
        }
    }
}
