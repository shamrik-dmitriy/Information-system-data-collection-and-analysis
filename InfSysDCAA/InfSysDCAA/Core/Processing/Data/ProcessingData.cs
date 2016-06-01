﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfSysDCAA.Core.Processing.Files;
using InfSysDCAA.Core.Processing.Devices;
using InfSysDCAA.Core.Processing.Direct_dimension;
using InfSysDCAA.Core.Processing.Test;

namespace InfSysDCAA.Core.Processing.Data
{
    /// <summary>
    /// Класс осуществляет работу с данными. 
    /// Инициирует и проводит тест.
    /// </summary>
    public class ProcessingData
    {
        private string FileName { get; set; }

        public ProcessingData(string fileName)
        {
            FileName = fileName;
            StartProcessing();
        }
        /// <summary>
        /// Запускает обработку файла, инициирует и проводит тестирование
        /// </summary>
        private void StartProcessing()
        {
            try
            {
                SourceProcessing processing = new SourceProcessing(FileName);
                SourceProcessing.ReaderBinaryFile();
                GetDeviceInfo infoDev = new GetDeviceInfo(SourceProcessing.getArrayInventoryNumber());
                DirectDimension processingDimension = new DirectDimension(SourceProcessing.RawStructDevice);
                Testing InitTest = new Testing(SourceProcessing.RawStructDevice, infoDev.XmlDeviceExport);
                InitTest.StartTest();
                //TODO:После анализа теста необходимо передать его результаты в класс отчётов, метод которого сформирует отчёт.
                //InitTest.GetResultTest();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
