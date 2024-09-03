import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./BusinessDeleteAccPage.css";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import $ from "jquery";

const BusinessDeleteAccPage = () => {
  const navigate = useNavigate();
  const [businessId, setBusinessId] = useState("");
  const [message, setMessage] = useState({ type: "", content: "" });

  const handleChange = (e) => {
    setBusinessId(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    $.ajax({
      url: `https://foodleftoversaver.azurewebsites.net/api/v1/Restaurant/delete/${businessId}`,
      method: "DELETE",
      success: function (response) {
        setMessage({
          type: "success",
          content: "Account deleted successfully!",
        });
        alert("Account deleted successfully!");
        navigate("/");
      },
      error: function (error) {
        console.error("Error deleting account:", error);
        setMessage({
          type: "error",
          content: "Failed to delete account. Please try again.",
        });
      },
    });
  };

  return (
    <>
      <Header />
      <div className="delete-account-container">
        <h1>Delete Account</h1>
        {message.content && (
          <div className={`message ${message.type}`}>{message.content}</div>
        )}
        <form onSubmit={handleSubmit} className="delete-account-form">
          <div className="form-group">
            <label htmlFor="businessId">Business ID:</label>
            <input
              type="text"
              id="businessId"
              name="businessId"
              value={businessId}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="delete-button">
            Delete Account
          </button>
        </form>
      </div>
      <Footer />
    </>
  );
};

export default BusinessDeleteAccPage;
