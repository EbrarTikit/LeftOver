import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./BusinessAddInventoryPage.css";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import $ from "jquery";
import { useEffect } from "react";

const BusinessAddInventoryPage = () => {
  const navigate = useNavigate();
  const [product, setProduct] = useState({
    restaurantId: "",
    itemName: "",
    price: "",
    picture: "",
    explanation: "",
  });
  const [message, setMessage] = useState({ type: "", content: "" });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProduct((prevProduct) => ({
      ...prevProduct,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    $.ajax({
      url: `https://foodleftoversaver.azurewebsites.net/api/v1/Item`,
      method: "POST",
      contentType: "application/json",
      data: JSON.stringify(product),
      success: function (response) {
        setMessage({ type: "success", content: "Product added successfully!" });
        setProduct({
          restaurantId: "",
          itemName: "",
          price: "",
          picture: "",
          explanation: "",
        });
      },
      error: function (error) {
        console.error("Error adding product:", error);
        setMessage({
          type: "error",
          content: "Failed to add product. Please try again.",
        });
      },
    });
  };

  useEffect(() => {
    document.title = "FoodLeftover | Business Add Inventory Page";
  }, []);

  return (
    <>
      <Header />
      <div className="add-inventory-container">
        <h1>Add New Inventory Item</h1>
        {message.content && (
          <div className={`message ${message.type}`}>{message.content}</div>
        )}
        <form onSubmit={handleSubmit} className="add-inventory-form">
          <div className="form-group">
            <label htmlFor="restaurantId">Restaurant ID:</label>
            <input
              type="number"
              id="restaurantId"
              name="restaurantId"
              value={product.restaurantId}
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
              value={product.itemName}
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
              value={product.price}
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
              value={product.picture}
              onChange={handleChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="explanation">Explanation:</label>
            <textarea
              id="explanation"
              name="explanation"
              value={product.explanation}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="add-button">
            Add Product
          </button>
        </form>
      </div>
      <Footer />
    </>
  );
};

export default BusinessAddInventoryPage;
