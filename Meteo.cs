using System;
using System.Collections.Generic; 
using System.Linq;


class WeatherData 
{
    private LinkedList<Observer> observers = new LinkedList<Observer>();

    public void registerObserver(Observer observer)   
    {
        observers.AddLast(observer);   
    }

    public void removeObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public void notifyObservers()
    {
        Console.Write("\nВведите новые показания датчиков:\nТемпература: ");
        float temperature = Convert.ToInt32(Console.ReadLine());  
        Console.Write("Влажность: ");
        float humidity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Давление: ");
        float pressure = Convert.ToInt32(Console.ReadLine());

        foreach (Observer observer in observers)
        {
            observer.update(temperature, humidity, pressure);
        } 
    }
}

interface Observer
{
    void update(float temperature, float humidity, float pressure);
    void display();
}

class CurrentDisplay : Observer
{
    private float temperature; 
    private float humidity; 
    private float pressure;

    public CurrentDisplay(WeatherData weatherData)
    {
        weatherData.registerObserver(this);
    }

    public void update(float temperature, float humidity, float pressure)
    {   
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        this.display();
    }

    public void display()
    {
        Console.WriteLine("\nTemperature: " + temperature);
        Console.WriteLine("Humidity: " + humidity);
        Console.WriteLine("Pressure: " + pressure);
    }
}

class StatisticsDisplay : Observer   
{
    public float[] AVtemp = { int.MaxValue };
    public float[] AVhumid = { int.MaxValue };
    public float[] AVpress = { int.MaxValue };

    public StatisticsDisplay(WeatherData weatherData)
    {
        weatherData.registerObserver(this);
    }

    public void update(float temperature, float humidity, float pressure)
    {
        if (AVtemp.Length == 1 && AVtemp[0] == int.MaxValue)
        {
            AVtemp[0] = temperature;
            AVhumid[0] = humidity;
            AVpress[0] = pressure;
        }

        else
        {
            Array.Resize(ref AVtemp, AVtemp.Length + 1);
            Array.Resize(ref AVhumid, AVhumid.Length + 1);
            Array.Resize(ref AVpress, AVpress.Length + 1);

            AVtemp[^1] = temperature; 
            AVhumid[^1] = humidity;
            AVpress[^1] = pressure;
        }

        this.display(); 
    }

    public void display()
    {
        float sum = 0;
        foreach (float t in AVtemp)
        {
            sum += t;
        }
        Console.WriteLine($"\nAverage Temperature: {sum / AVtemp.Length}");

        sum = 0;
        foreach (float h in AVhumid)
        {
            sum += h;
        }
        Console.WriteLine($"Average Humidity: {sum / AVhumid.Length}");

        sum = 0;
        foreach (float p in AVpress)
        {
            sum += p;
        }
        Console.WriteLine($"Average Pressure: {sum / AVpress.Length}");

    }
}

class ForecastDisplay : Observer
{
    private float[] FUTemp = { int.MaxValue };
    private float[] FUThumid = { int.MaxValue };
    private float[] FUTpress = { int.MaxValue };

    public ForecastDisplay(WeatherData weatherData)
    {
        weatherData.registerObserver(this);
    }

    public void update(float temperature, float humidity, float pressure)
    {

        if (FUTemp.Length == 1 && FUTemp[0] == int.MaxValue)
        {
            FUTemp[0] = temperature;
            FUThumid[0] = humidity;
            FUTpress[0] = pressure;
        }

        else
        {
            Array.Resize(ref FUTemp, FUTemp.Length + 1);
            Array.Resize(ref FUThumid, FUThumid.Length + 1);
            Array.Resize(ref FUTpress, FUTpress.Length + 1);

            FUTemp[^1] = temperature;  
            FUThumid[^1] = humidity;
            FUTpress[^1] = pressure;
        }

        this.display();
    }

    public void display()
    {
        Console.WriteLine();

        float FOREtemp;
        float FOREhumid;
        float FOREpress;

        if (FUTemp.Length == 1) { FOREtemp = FUTemp[0] + 1; }
        else if (FUTemp.Length == 2) { FOREtemp = (FUTemp[0] + FUTemp[1]) / 2 - 1; }
        else { FOREtemp = (FUTemp[^1] + FUTemp[^2] + FUTemp[^3]) / 3 + 2; }
        Console.WriteLine("Temperature Forecast: " + FOREtemp);

        if (FUThumid.Length == 1) { FOREhumid = FUThumid[0] + 1; }
        else if (FUThumid.Length == 2) { FOREhumid = (FUThumid[0] + FUThumid[1]) / 2 - 1; }
        else { FOREhumid = (FUThumid[^1] + FUThumid[^2] + FUThumid[^3]) / 3 + 2; }
        Console.WriteLine("Humidity Forecast: " + FOREhumid);

        if (FUTpress.Length == 1) { FOREpress = FUTpress[0] + 1; }
        else if (FUTpress.Length == 2) { FOREpress = (FUTpress[0] + FUTpress[1]) / 2 - 1; }
        else { FOREpress = (FUTpress[^1] + FUTpress[^2] + FUTpress[^3]) / 3 + 2; }
        Console.WriteLine("Pressure Forecast: " + FOREpress);
    }
}


class Program
{
    static void Main(string[] args)
    {
        var weatherData = new WeatherData();

        var currentDisplay = new CurrentDisplay(weatherData);
        var statisticsDisplay = new StatisticsDisplay(weatherData);
        var forecastDisplay = new ForecastDisplay(weatherData);

        var stop = 1;
        while (stop != 0)
        {
            weatherData.notifyObservers();  

            Console.WriteLine("\nЕсть еще данные для анализа?\t(1) YES\t(2) NO\n");
            stop = Convert.ToInt32(Console.ReadLine());

        }
    }
}
