// src/components/ProductCard.js
import React from "react";
import "./ProductCard.css";

const ProductCard = ({ product }) => {
  return (
    <div className="card">
      <img src={product.picture} alt={product.itemName} />
      <div className="card-content">
        <h3>{product.itemName}</h3>
        <p>{product.explanation}</p>
        <p className="price">${product.price}</p>
      </div>
    </div>
  );
};

export default ProductCard;
