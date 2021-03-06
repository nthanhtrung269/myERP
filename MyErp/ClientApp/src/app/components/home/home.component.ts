// =============================
// Email: nthanhtrung269@gmail.com
// https://www.nguyenthanhtrung.net
// =============================

import { Component } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { ConfigurationService } from '../../services/configuration.service';


@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
    animations: [fadeInOut]
})
export class HomeComponent {
    constructor(public configurations: ConfigurationService) {
    }
}
