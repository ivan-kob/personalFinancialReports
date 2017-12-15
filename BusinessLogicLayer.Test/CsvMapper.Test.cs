using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Test
{
    [TestClass]
    public class UnitTest1
    {
        #region GetListFromStream
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetListFromStream_NullStreamArgument_ThowsArgumentNullException()
        {
            //Arrange
            StreamReader nullStreamReader = null;

            //Act
            CsvMapper.GetListFromStream<Transaction>(nullStreamReader);

            //Assert is handled by the expected exception
            
        }

        [TestMethod]
        public void GetListFromStream__ValidStreamArgument_ReturnsListOfMappedObjects()
        {
            //Arrange
            string testCsvFileLocation = $"{AppDomain.CurrentDomain.BaseDirectory}/TestFiles/CsvTestFile.csv";
            StreamReader validStream = new StreamReader(testCsvFileLocation);
            //Act
            IList<Transaction> emptyList = CsvMapper.GetListFromStream<Transaction>(validStream);
            //Assert
            Assert.AreNotEqual(null, emptyList);
            Assert.AreEqual(true, emptyList.Count > 0);
        }

        [TestMethod]
        public void GetListFromStream_EmptyStream_ReturnsEmptyListOfObjects()
        {
            //Arrange
            string testCsvFileLocation = $"{AppDomain.CurrentDomain.BaseDirectory}/TestFiles/EmptyCsvFile.csv";
            StreamReader emptyStream = new StreamReader(testCsvFileLocation);
            //Act
            IList<Transaction> emptyList = CsvMapper.GetListFromStream<Transaction>(emptyStream);
            //Assert
            Assert.AreNotEqual(null, emptyList);
            Assert.AreEqual(true, emptyList.Count == 0);
        }
        #endregion

    }
}
