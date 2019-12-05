using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using DataAccessLayer;
using BusinessEntities;
using System.Collections;
using System.Collections.Generic;

#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{
	[TestClass]
	public class UnitTestsBusinessLayer
	{
		[TestMethod]
		public void TestAddUser_ValidUser_ReturnsTrue()
		{
			// arrange
			IDataLayer FakeDatalayer = new StubDataLayer();
			IModel _Model = Model.GetInstance(FakeDatalayer); // The code I want to test is in the real Model class
			_Model.UserList.Clear(); // User objects loaded from Login method so list should be empty, but clearing just in case

									 // act
			bool result = _Model.addNewUser("Brendan", "password", "m");
			/* The addNewUser method called above will call the DataLayer addNewUserToDB
			* but as the model is primed with the FakeDataLayer no DB code is invoked
			* as this is all overridden in the fake. This allows testing of the logic
			* inside the Models addNewUser in isolation of any DB. ie don't need a DB at all.
			* This means there is no setup or configuration needed to run this (or any) unit test.
			* */
			// assert
			Assert.IsTrue(result); // I expect True
		}

		[TestMethod]
		public void TestAddUser_DuplicateUser_ReturnsFalse()
		{
			// arrange
			IDataLayer FakeDatalayer = new StubDataLayer();
			IModel _Model = Model.GetInstance(FakeDatalayer); // The code I want to test is in the real Model class
			_Model.UserList.Clear(); // clear userList 
			IUser aUser = new User("Pat", "Password", "m", 1); // sets up a user we will try to add a duplicate for test
			_Model.UserList.Add(aUser); // add the user ref to the userList
										// act
			bool result = _Model.addNewUser("Brendan", "password", "m"); // now try to add Brendan again

																			// assert
			Assert.IsFalse(result); // I expect false ie a false result willpass the test
		}

		[TestMethod]
		public void TestAddUser_UserNameTooShort_ReturnsFalse()
		{
			// arrange
			IDataLayer FakeDatalayer = new StubDataLayer();
			IModel _Model = Model.GetInstance(FakeDatalayer); // The code I want to test is in the real Model class
			_Model.UserList.Clear(); // User objects loaded from Login method so list should be empty, but clearing just in case
									 // act
			bool result = _Model.addNewUser("Br", "password", "m"); // now try to add Brendan again

																	   // assert
			Assert.IsFalse(result); // I expect false ie a false result willpass the test
		}

		[TestMethod]
		public void TestAddUser_PasswordTooShort_ReturnsFalse()
		{
			// arrange
			IDataLayer FakeDatalayer = new StubDataLayer();
			IModel _Model = Model.GetInstance(FakeDatalayer); // The code I want to test is in the real Model class
			_Model.UserList.Clear(); // User objects loaded from Login method so list should be empty, but clearing just in case
									 // act
			Boolean result = _Model.addNewUser("Brendan", "pass", "m"); // now try to add Brendan again

																		// assert
			Assert.IsFalse(result); // I expect false ie a false result willpass the test
		}
	
	}


	public class StubDataLayer : DataLayer
	{

		public StubDataLayer()
		{

		}
		public override void addNewUserToDB(IUser theUser)
		{
			// no code it's a fake
		}

		public override void openConnection()
		{
			// no code it's a fake
		}
		public override void closeConnection()
		{
			// no code it's a fake
		}

		public override List<IUser> getAllUsers()
		{
			List<IUser> UserList = new List<IUser>();
			return UserList; // just return an empty userList, it's a fake
		}
	}
}