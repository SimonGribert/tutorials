//
//  UIColor+Ext.swift
//  RandomColors
//
//  Created by Simon Gribert on 2022-11-06.
//

import UIKit

extension UIColor {
    static func random() -> UIColor {
        let randomColor = UIColor(
            red: CGFloat.random(in: 0...1),
            green: CGFloat.random(in: 0...1),
            blue: CGFloat.random(in: 0...1),
            alpha: 1
        )
        
        return randomColor
    }
}
