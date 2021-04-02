using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constant.Message
{
    public class Messages
    {
        public static string CarAdded = "Successfully added car ";
        public static string InvalidCarAdded = "Sorry, cannot add car ";
        public static string CarDeleted = "Successfully deleted car ";
        public static string CarUpdated = "Successfully updated car ";
        public static string CarListed = "Cars are listed";
        public static string CarById = "Car is here";
        public static string MaintenanceTime = "Car not listed";
        public static string CarNotEmpty = "Car name is can not empty";
        public static string CarMinimumLength = "Car name must be greater than two characters";
        public static string CarGreaterThan = "Car daily price must be greater than '0'";




        public static string ColorAdded = "Successfully added color ";
        public static string ColorDeleted = "Successfully deleted color ";
        public static string ColorUpdated = "Successfully updated color ";
        public static string ColorListed = "Colors are listed";
        public static string ColorById = "Color is here";
        public static string ColorNameNotEmpty = "Color name is can not empty";
        public static string ColorNameMinimumLength = "Color name must be greater than two characters ";



        public static string BrandAdded = "Successfully added brand ";
        public static string BrandDeleted = "Successfully deleted brand ";
        public static string BrandUpdated = "Successfully updated brand ";
        public static string BrandListed = "Brands are listed";
        public static string BrandById = "Brand is here";
        public static string BrandNameNotEmpty = "Brand name is can not empty";
        public static string BrandNameMinimumLength = "Brand name must be greater than two characters ";



        public static string UserAdded = "Successfully added user ";
        public static string UserDeleted = "Successfully deleted user ";
        public static string UserUpdated = "Successfully updated user ";
        public static string UserListed = "Users are listed";
        public static string UserFirstNameNotEmpty = "First name is can not empty";
        public static string UserFirstNameMinimumLength = "First name must be greater than three characters ";
        public static string UserLastNameNotEmpty = "Last name is can not empty";
        public static string UserLastNameMinimumLength = "Last name must be greater than three characters ";
        public static string UserEmailNotEmpty = "Email is can not empty";
        public static string UserMinimumLength = "Email must be greater than three characters ";
        public static string UserEmailEmailAddress = "A valid email address is required.";
        public static string UserPasswordMinimumLength = "Password must be greater than eight characters ";
        public static string UserPasswordNotEmpty = "Password is can not empty";



        public static string CustomerAdded = "Successfully added customer ";
        public static string CustomerDeleted = "Successfully deleted customer ";
        public static string CustomerUpdated = "Successfully updated customer ";
        public static string CustomerListed = "Customers are listed";
        public static string CustomerCompanyNameNotEmpty = "Company name is can not empty";
        public static string CustomerCompanyNameMinimumLength = "Company name must be greater than three characters ";



        public static string RentalDeleted = "Successfully deleted rental ";
        public static string RentalUpdated = "Successfully updated rental ";
        public static string InvalidRental = "This car is not currently available";
        public static string RentalAdded = "This car is available now. Car rental successful";
        public static string RentalListed = "Rentals are listed";
        public static string RentalCarIdNotEmpty = "Car ID is can not empty";
        public static string RentalRentDateNotEmpty = "Rental date is can not empty";
        public static string RentalCustomerIdNotEmpty = "Customer ID is can not empty";
        public static string RentalDetailListed = "Rental details are listed";


        public static string CarImageIdNotEmpty = "Car image id is not empty";
        public static string CarImageCount = "Cannot add more than 5 photos ";
        public static string CarImagePathNotEmpty = "Image path  is not empty";
        public static string CarDateNotEmpty = "Date is not empty";




        public static string CarImageUpdated = "Car image updated successfully";
        public static string CarImageDeleted = "Car image was deleted";
        public static string CarImageAdded = "Car image was added";
        public static string CarImageListed = "Car image was listed";
        public static string CarImageNotAdded = "Car image was not added";
        public static string CarIdIdNotEmpty = "Car id is not empty";
        public static string UserNotFound = "User not found";
        public static string PasswordError= "Password is wrong";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExist = "User already exist";
        public static string UserRegistered = "User was successfully registered";
        public static string AccessTokenCreated = "Token was created";
        public static string NotAutorized = "You are not authorized";
        
    }
}
