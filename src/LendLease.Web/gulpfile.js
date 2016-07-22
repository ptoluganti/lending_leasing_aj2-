/// <reference path="js/site.js" />
/// <reference path="js/site.js" />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
     typescript = require('gulp-typescript'),
    sourcemaps = require('gulp-sourcemaps'),
      tscConfig = require('./tsconfig.json');

gulp.task('copylibs', function () {
    return gulp
      .src([
        'node_modules/es6-shim/es6-shim.min.js',
        'node_modules/systemjs/dist/system-polyfills.js',
        'node_modules/angular2/bundles/angular2-polyfills.js',
        'node_modules/systemjs/dist/system.src.js',
        'node_modules/rxjs/bundles/Rx.js',
        'node_modules/angular2/bundles/angular2.dev.js'
      ])
      .pipe(gulp.dest('wwwroot/lib/angular2'));
});

gulp.task('typescript', function () {
    return gulp
      .src([
          'js/site.js',
          "js/app.component.js"
      ])
      .pipe(gulp.dest('wwwroot/js'));
});


gulp.task('default', ['copylibs', 'typescript']);