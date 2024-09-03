import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./UpdateLocationPage.css";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import $ from "jquery";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";
import { useAuth } from "../../AuthContext";
import { useLocation } from "react-router-dom";

const UpdateLocationPage = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    id: "",
    streetInformation: "",
    city: "",
    postalCode: "",
    country: "",
    storeType: "",
    name: "",
    email: "",
    password: "",
    phoneNumber: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    $.ajax({
      url: `https://foodleftoversaver.azurewebsites.net/api/v1/Restaurant/update/${formData.id}`,
      method: "PUT",
      contentType: "application/json",
      data: JSON.stringify(formData),
      success: function (response) {
        alert("Location updated successfully!");
        navigate("/database");
      },
      error: function (error) {
        console.error("Error updating location:", error);
        alert("Failed to update location. Please check again.");
      },
    });
  };

  return (
    <>
      <Header />
      <div className="update-location-container">
        <h1>Update Informations</h1>
        <form onSubmit={handleSubmit} className="update-location-form">
          <div className="form-group">
            <label htmlFor="id">Business ID:</label>
            <input
              type="text"
              id="id"
              name="id"
              value={formData.id}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="streetInformation">Street Information:</label>
            <input
              type="text"
              id="streetInformation"
              name="streetInformation"
              value={formData.streetInformation}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="city">City:</label>
            <input
              type="text"
              id="city"
              name="city"
              value={formData.city}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="postalCode">Postal Code:</label>
            <input
              type="text"
              id="postalCode"
              name="postalCode"
              value={formData.postalCode}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="country">Country:</label>
            <input
              type="text"
              id="country"
              name="country"
              value={formData.country}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="storeType">Store Type:</label>
            <input
              type="text"
              id="storeType"
              name="storeType"
              value={formData.storeType}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="name">Name:</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="email">Email:</label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="password">Password:</label>
            <input
              type="password"
              id="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="phoneNumber">Phone Number:</label>
            <input
              type="text"
              id="phoneNumber"
              name="phoneNumber"
              value={formData.phoneNumber}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="update-button">
            Update Informations
          </button>
        </form>
      </div>
      <Footer />
    </>
  );
};

export default UpdateLocationPage;
