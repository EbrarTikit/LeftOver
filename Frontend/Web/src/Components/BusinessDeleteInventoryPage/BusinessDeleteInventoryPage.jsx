import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./BusinessDeleteInventoryPage.css";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import $ from "jquery";
import { useEffect } from "react";

const BusinessDeleteInventoryPage = () => {
  const navigate = useNavigate();
  const [itemId, setItemId] = useState("");
  const [message, setMessage] = useState({ type: "", content: "" });

  const handleChange = (e) => {
    setItemId(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    $.ajax({
      url: `https://foodleftoversaver.azurewebsites.net/api/v1/Item/${itemId}`,
      method: "DELETE",
      success: function (response) {
        setMessage({ type: "success", content: "Item deleted successfully!" });
      },
      error: function (error) {
        console.error("Error deleting item:", error);
        setMessage({
          type: "error",
          content: "Failed to delete item. Please try again.",
        });
      },
    });
  };

  useEffect(() => {
    document.title = "FoodLeftover | Business Delete Inventory Page";
  }, []);

  return (
    <>
      <Header />
      <div className="delete-inventory-container">
        <h1>Delete Inventory Item</h1>
        {message.content && (
          <div className={`message ${message.type}`}>{message.content}</div>
        )}
        <form onSubmit={handleSubmit} className="delete-inventory-form">
          <div className="form-group">
            <label htmlFor="itemId">Item ID:</label>
            <input
              type="text"
              id="itemId"
              name="itemId"
              value={itemId}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="delete-button">
            Delete Item
          </button>
        </form>
      </div>
      <Footer />
    </>
  );
};

export default BusinessDeleteInventoryPage;
