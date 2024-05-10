package com.example.foodleftoversaver.adapter

/** This is adapter for horizontal recycleviews */

/*
import android.R
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.CheckBox
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView


class HorizontalAdapter(data: List<Business>) :
    RecyclerView.Adapter<HorizontalAdapter.ViewHolder>() {
    private val mData: List<Business>

    init {
        mData = data
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view: View =
            LayoutInflater.from(parent.context).inflate(R.layout.hor, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val business: Business = mData[position]

        // Bind data to views
        holder.imageView.setImageResource(business.getImageResId())
        holder.nameTextView.setText(business.getName())
        holder.distanceTextView.setText(business.getDistance())
        holder.rateTextView.setText(business.getRate())
        holder.favoriteCheckBox.isChecked = business.isFavorite()
    }

    override fun getItemCount(): Int {
        return mData.size
    }

    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        var imageView: ImageView
        var nameTextView: TextView
        var distanceTextView: TextView
        var rateTextView: TextView
        var favoriteCheckBox: CheckBox

        init {
            imageView = itemView.findViewById<ImageView>(R.id.image_business)
            nameTextView = itemView.findViewById<TextView>(R.id.text_business_name)
            distanceTextView = itemView.findViewById<TextView>(R.id.text_distance)
            rateTextView = itemView.findViewById<TextView>(R.id.text_rate)
            favoriteCheckBox = itemView.findViewById<CheckBox>(R.id.checkbox_favorite)
        }
    }
}
*/
