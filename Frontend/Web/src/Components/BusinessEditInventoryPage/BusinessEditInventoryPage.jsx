import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./BusinessEditInventoryPage.css";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import $ from "jquery";

const BusinessEditInventoryPage = () => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    id: "",
    itemName: "",
    price: "",
    picture: "",
    explanation: "",
  });
  const [message, setMessage] = useState({ type: "", content: "" });

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
      url: `https://foodleftoversaver.azurewebsites.net/api/v1/Item/${formData.id}`,
      method: "PUT",
      contentType: "application/json",
      data: JSON.stringify(formData),
      success: function (response) {
        setMessage({ type: "success", content: "Item updated successfully!" });
      },
      error: function (error) {
        console.error("Error updating item:", error);
        setMessage({
          type: "error",
          content: "Failed to update item. Please try again.",
        });
      },
    });
  };

  return (
    <>
      <Header />
      <div className="edit-inventory-container">
        <h1>Edit Inventory Item</h1>
        {message.content && (
          <div className={`message ${message.type}`}>{message.content}</div>
        )}
        <form onSubmit={handleSubmit} className="edit-inventory-form">
          <div className="form-group">
            <label htmlFor="id">Item ID:</label>
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
            <label htmlFor="itemName">Item Name:</label>
            <input
              type="text"
              id="itemName"
              name="itemName"
              value={formData.itemName}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="price">Price:</label>
            <input
              type="number"
              id="price"
              name="price"
              value={formData.price}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="picture">Picture URL:</label>
            <input
              type="text"
              id="picture"
              name="picture"
              value={formData.picture}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="explanation">Explanation:</label>
            <textarea
              id="explanation"
              name="explanation"
              value={formData.explanation}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="edit-button">
            Update Item
          </button>
        </form>
      </div>
      <Footer />
    </>
  );
};

export default BusinessEditInventoryPage;
