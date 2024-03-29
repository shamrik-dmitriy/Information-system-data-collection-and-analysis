﻿using InfSysDCAA.Core.Directory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using InfSysDCAA.Core.Processing;
using InfSysDCAA.Core.Processing.Devices;

namespace InfSysDCAA.Core.XML.Devices.Reader
{
    /// <summary>
    /// Выполняет чтение данных из XML файлов
    /// </summary>
    public class ReaderParamsXML
    {
        /// <summary>
        /// Устанавливает или возвращает имя файла для поиска.
        /// </summary>
        private string FileNameParams { get; set; }

        /// <summary>
        /// Содержит число инвентарных номеров, или устройств,
        /// входящих в тест.
        /// </summary>
        private int CountInvetntNumbers { get; set; }

        /// <summary>
        /// Временный счетчик. -1 Для того, что бы правильно считать. 
        /// Счёт идет от числа всех - 1
        /// </summary>
        private int CountTmp { get; set; }

        /// <summary>
        /// Число устройств, постоянное
        /// </summary>
        private int ConstantInv { get; set; }

        /// <summary>
        /// Содержит полный путь до файла.
        /// </summary>
        private string FullPathToFile => DirectoryList.DefaultPathList[1] + "\\" + FileNameParams;

        /// <summary>
        /// Содержит данные для анализа
        /// </summary>
        private ConstantDeviceStruct.TmpDevice XMLDevice;

        /// <summary>
        /// Массив структур для экспорта в класс процесса
        /// </summary>
        public ConstantDeviceStruct.TmpDevice[] XmlDeviceExport;

        /// <summary>
        /// Просто офигительный массив структур для опупенного метода реверса!
        /// </summary>
        public ConstantDeviceStruct.TmpDevice[] SuperXmlDeviceExport;

        /// <summary>
        /// Принимает массив инвентарных номеров устройств, входящих в тест.
        /// Инвентарные номера используются для поиска файлов с данными 
        /// в системном каталоге программы
        /// </summary>
        /// <param name="inventNumber"> []String, массив нвентарных номеров</param>
        public ReaderParamsXML(string[] inventNumber)
        {
            AddedDotXML(inventNumber);
            CountInvetntNumbers = inventNumber.Count();
            PreparePermanentData();
            PasreArrayStringInventoryNumber(inventNumber);
        }

        //Необходимо разобрать массив номеров на отдельные строки, считать данные из файлов, 
        //и сделать их публично доступными
        /// <summary>
        /// Производит разбивку массива строк на отдельные элементы и передаёт их в обработку
        /// дальнейшим методам
        /// </summary>
        /// <param name="ArrayString"></param>
        private void PasreArrayStringInventoryNumber(string[] arrayString)
        {
            string tmp = "";
            for (int i = 0; i < arrayString.Count(); i++)
            {
                FileNameParams = arrayString[i];
                tmp = arrayString[i].Replace(".xml", "");
                XMLFileReader(tmp);
            }
        }

        public void XMLFileReader(string inv)
        {
            try
            {
                if (FindFileInThePath())
                {
                    PrepareData();
                    CountTmp = CountInvetntNumbers - 1;
                    ConstantInv = CountInvetntNumbers - 1;
                    ExtractXMLData();/////////////////////////////////
                }
                else
                {
                    //TODO: Вынести в отдельный файл ошибки.
                    string errMsg = "Файл устройства с инвентарным номером " + inv + "не найден";
                    throw new Exception(errMsg);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Инициализирует:
        ///  - List'ы в структуре;
        ///  - Массив структур и их List'ы
        /// </summary>
        public void PrepareData()
        {
            XMLDevice = new ConstantDeviceStruct.TmpDevice();
            XMLDevice.ReceiverDifferentialInputVoltage = new List<double>();
            XMLDevice.TransmitterDifferentialOutputVoltage = new List<double>();
            XMLDevice.TransmitterRiseRecessionSignalTime = new List<double>();
            XMLDevice.PowerReqPlusFiveVoltage = new List<double>();
            XMLDevice.PowerReqMinusTwelveVoltage = new List<double>();
            XMLDevice.PowerReqPlusTwelvePauseVoltage = new List<double>();
            XMLDevice.PowerReqPlusTwelve25Voltage = new List<double>();
            XMLDevice.PowerReqPlusTwelve50Voltage = new List<double>();
            XMLDevice.PowerReqPlusTwelve100Voltage = new List<double>();
            XMLDevice.Temperature = new List<double>();
        }

        /// <summary>
        /// Инициализирует структуру для долговременного хранения данных
        /// </summary>
        private void PreparePermanentData()
        {
            //Создадим и проведем инициализацию массива структур
            XmlDeviceExport = new ConstantDeviceStruct.TmpDevice[CountInvetntNumbers];
            SuperXmlDeviceExport = new ConstantDeviceStruct.TmpDevice[CountInvetntNumbers];
            for (int i = 0; i < CountInvetntNumbers; i++)
            {
                XmlDeviceExport[i].ReceiverDifferentialInputVoltage = new List<double>();
                SuperXmlDeviceExport[i].ReceiverDifferentialInputVoltage = new List<double>();
                XmlDeviceExport[i].PowerReqMinusTwelveVoltage = new List<double>();
                SuperXmlDeviceExport[i].PowerReqMinusTwelveVoltage = new List<double>();
                XmlDeviceExport[i].PowerReqPlusFiveVoltage = new List<double>();
                SuperXmlDeviceExport[i].PowerReqPlusFiveVoltage = new List<double>();
                XmlDeviceExport[i].PowerReqPlusTwelve100Voltage = new List<double>();
                SuperXmlDeviceExport[i].PowerReqPlusTwelve100Voltage = new List<double>();
                XmlDeviceExport[i].PowerReqPlusTwelve25Voltage = new List<double>();
                SuperXmlDeviceExport[i].PowerReqPlusTwelve25Voltage = new List<double>();
                XmlDeviceExport[i].PowerReqPlusTwelve50Voltage = new List<double>();
                SuperXmlDeviceExport[i].PowerReqPlusTwelve50Voltage = new List<double>();
                XmlDeviceExport[i].PowerReqPlusTwelvePauseVoltage = new List<double>();
                SuperXmlDeviceExport[i].PowerReqPlusTwelvePauseVoltage = new List<double>();
                XmlDeviceExport[i].Temperature = new List<double>();
                SuperXmlDeviceExport[i].Temperature = new List<double>();
                XmlDeviceExport[i].TransmitterDifferentialOutputVoltage = new List<double>();
                SuperXmlDeviceExport[i].TransmitterDifferentialOutputVoltage = new List<double>();
                XmlDeviceExport[i].TransmitterRiseRecessionSignalTime = new List<double>();
                SuperXmlDeviceExport[i].TransmitterRiseRecessionSignalTime = new List<double>();
            }
        }

        /// <summary>
        /// Извлекает данные из файла и записывает их в 
        /// List'ы. 
        /// <warning> СКЛАДЫВАЕТ В РЕЗУЛЬТАТ В ОБРАТНОМ ПОРЯДКЕ!!!!</warning>
        /// </summary>
        private void ExtractXMLData()
        {
            // Загружаем XML-файл
            XDocument XMLData = XDocument.Load(FullPathToFile);
            // Обходим XML файл начиная с корня.
            foreach (XElement element in XMLData.Root.Elements())
            {
                //В ветке ресивера:
                foreach (XElement ReceiverElement in element.Elements("DifferentialInputVoltage"))
                {
                    XElement Limit = ReceiverElement.Element("Limit");
                    XElement Minimum = ReceiverElement.Element("Minimum");
                    XElement Maximum = ReceiverElement.Element("Maximum");
                    //Нижняя граница
                    XMLDevice.ReceiverDifferentialInputVoltage.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.ReceiverDifferentialInputVoltage.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верхняя граница
                    XMLDevice.ReceiverDifferentialInputVoltage.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.ReceiverDifferentialInputVoltage.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                //Ветка трансмиттера
                foreach (XElement TransmitterElementDiffOutV in element.Elements("DifferentialOutputVoltage"))
                {
                    XElement Minimum = TransmitterElementDiffOutV.Element("Minimum");
                    XElement Normal = TransmitterElementDiffOutV.Element("Normal");
                    XElement Limit = TransmitterElementDiffOutV.Element("Limit");
                    //Низ
                    XMLDevice.TransmitterDifferentialOutputVoltage.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.TransmitterDifferentialOutputVoltage.Add(Convert.ToDouble(Normal.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.TransmitterDifferentialOutputVoltage.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.TransmitterDifferentialOutputVoltage.Add(Convert.ToDouble(Normal.Value) + Convert.ToDouble(Limit.Value));
                }
                foreach (XElement TransmitterElementTimeUpDownS in element.Elements("TimeToUpDownSignal"))
                {
                    XElement Minimum = TransmitterElementTimeUpDownS.Element("Minimum");
                    XElement Maximum = TransmitterElementTimeUpDownS.Element("Maximum");
                    XElement Limit = TransmitterElementTimeUpDownS.Element("Limit");
                    //Низ
                    XMLDevice.TransmitterRiseRecessionSignalTime.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.TransmitterRiseRecessionSignalTime.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.TransmitterRiseRecessionSignalTime.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.TransmitterRiseRecessionSignalTime.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                //Ветка требования по питанию
                foreach (XElement PlusFiveVolt in element.Elements("PlusFiveVolt"))
                {
                    XElement Maximum = PlusFiveVolt.Element("Maximum");
                    XElement Limit = PlusFiveVolt.Element("Limit");
                    //Низ
                    XMLDevice.PowerReqPlusFiveVoltage.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.PowerReqPlusFiveVoltage.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                foreach (XElement MinusTwelvVolt in element.Elements("MinusTwelvVolt"))
                {
                    XElement Maximum = MinusTwelvVolt.Element("Maximum");
                    XElement Limit = MinusTwelvVolt.Element("Limit");
                    //Низ
                    XMLDevice.PowerReqMinusTwelveVoltage.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.PowerReqMinusTwelveVoltage.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                foreach (XElement PlusTwelvVoltPause in element.Elements("PlusTwelvVoltPause"))
                {
                    XElement Minimum = PlusTwelvVoltPause.Element("Minimum");
                    XElement Maximum = PlusTwelvVoltPause.Element("Maximum");
                    XElement Limit = PlusTwelvVoltPause.Element("Limit");
                    //Низ
                    XMLDevice.PowerReqPlusTwelvePauseVoltage.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelvePauseVoltage.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.PowerReqPlusTwelvePauseVoltage.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelvePauseVoltage.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                foreach (XElement PlusTwelvVoltTwentyFive in element.Elements("PlusTwelvVoltTwentyFive"))
                {
                    XElement Minimum = PlusTwelvVoltTwentyFive.Element("Minimum");
                    XElement Maximum = PlusTwelvVoltTwentyFive.Element("Maximum");
                    XElement Limit = PlusTwelvVoltTwentyFive.Element("Limit");
                    //Низ
                    XMLDevice.PowerReqPlusTwelve25Voltage.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelve25Voltage.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.PowerReqPlusTwelve25Voltage.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelve25Voltage.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                foreach (XElement PlusTwelvVoltFifty in element.Elements("PlusTwelvVoltFifty"))
                {
                    XElement Minimum = PlusTwelvVoltFifty.Element("Minimum");
                    XElement Maximum = PlusTwelvVoltFifty.Element("Maximum");
                    XElement Limit = PlusTwelvVoltFifty.Element("Limit");
                    //Низ
                    XMLDevice.PowerReqPlusTwelve50Voltage.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelve50Voltage.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.PowerReqPlusTwelve50Voltage.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelve50Voltage.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                foreach (XElement PlusTwelvVoltHundred in element.Elements("PlusTwelvVoltHundred"))
                {
                    XElement Minimum = PlusTwelvVoltHundred.Element("Minimum");
                    XElement Limit = PlusTwelvVoltHundred.Element("Limit");
                    XElement Maximum = PlusTwelvVoltHundred.Element("Maximum");
                    //Низ
                    XMLDevice.PowerReqPlusTwelve100Voltage.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelve100Voltage.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.PowerReqPlusTwelve100Voltage.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.PowerReqPlusTwelve100Voltage.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
                // Ветка температуры
                foreach (XElement temperature in element.Elements("PowerTemp"))
                {
                    XElement Minimum = temperature.Element("Minimum");
                    XElement Maximum = temperature.Element("Maximum");
                    XElement Limit = temperature.Element("Limit");
                    //Низ
                    XMLDevice.Temperature.Add(Convert.ToDouble(Minimum.Value) - Convert.ToDouble(Limit.Value));
                    XMLDevice.Temperature.Add(Convert.ToDouble(Maximum.Value) - Convert.ToDouble(Limit.Value));
                    //Верх
                    XMLDevice.Temperature.Add(Convert.ToDouble(Minimum.Value) + Convert.ToDouble(Limit.Value));
                    XMLDevice.Temperature.Add(Convert.ToDouble(Maximum.Value) + Convert.ToDouble(Limit.Value));
                }
            }
            SaveTheData(CountTmp);
            //Уменьшаем число устройств
            CountInvetntNumbers--;
        }

        /// <summary>
        /// После того, как данные очередного XML файла прочитаны, сохраняем их.
        /// </summary>
        private void SaveTheData(int count)
        {
            XmlDeviceExport[count] = XMLDevice;
            if (count == 0)
            {
                XmlDeviceExport = MySuperFunctionReverse(XmlDeviceExport);
            }
        }

        /// <summary>
        /// Мой супер опупенный метод реверса массива структур.
        /// Просто обалденнейший метод!
        /// </summary>
        /// <param name="t">Массив структур</param>
        /// <returns>Самый отзеркальнный массив из всех когда либо отзеркаленных!</returns>
        private ConstantDeviceStruct.TmpDevice[] MySuperFunctionReverse(ConstantDeviceStruct.TmpDevice[] t)
        {
            int j = 0;
            for (int i = t.Count() - 1; i >= 0; i--)
            {
                SuperXmlDeviceExport[j] = t[i];
                j++;
            }
            return SuperXmlDeviceExport;
        }

        /// <summary>
        /// Проверяет, существует ли XML-файл с параметрами в папке.
        /// </summary>
        /// <returns>Возвращает истину, если файл есть, и ложь, если файла нет</returns>
        private bool FindFileInThePath()
        {
            if (File.Exists(FullPathToFile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Добавляет к каждому инвентарному номеру в массиве ".xml"
        /// и возвращает модифицированный массив
        /// </summary>
        /// <param name="str">[]string, массив инвентарных номеров с .xml в конце у каждого.</param>
        /// <returns></returns>
        private string[] AddedDotXML(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i] + ".xml";
            }
            return str;
        }
    }
}
