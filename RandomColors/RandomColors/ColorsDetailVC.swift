//
//  ColorsDetailVC.swift
//  RandomColors
//
//  Created by Simon Gribert on 2022-11-06.
//

import UIKit

class ColorsDetailVC: UIViewController {
    var color: UIColor?

    override func viewDidLoad() {
        super.viewDidLoad()
        
        view.backgroundColor = color ?? .blue
    }
}
