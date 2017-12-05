using System;
using System.Collections;
using System.Collections.Generic;

namespace Observer
{
    public class WeatherStation
    {
        public static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            
            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            //StatisticsDisplay currentDisplay = new StatisticsDisplay(weatherData);
            //ForecastDisplay currentDisplay = new ForecastDisplay(weatherData);
            
            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.4f);
            weatherData.SetMeasurements(78, 90, 29.4f);
            
            
        }
    }

    public interface Subject
    {
        void RegisterObserver(Observer o);
        void RemoveObserver(Observer o);
        void NotifyObservers(); 
    }

    public interface Observer
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface DisplayElement
    {
        void Display();
    }

    public class WeatherData : Subject
    {
        private List<Observer> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers = new List<Observer>();
        }

        public void RegisterObserver(Observer o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(Observer o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (Observer o in observers)
            {
                o.Update(temperature, humidity, pressure);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementsChanged();
        }
    }

    public class CurrentConditionsDisplay : Observer, DisplayElement
    {
        private float temperature;
        private float humidity;
        private Subject weatherData;

        public CurrentConditionsDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + temperature
                              + "F degrees and " + humidity + "% humidity");
        }
    }
    
    
}