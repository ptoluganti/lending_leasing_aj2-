/// <reference path="js/customer/icustomer.js" />
/// <reference path="js/site.js" />
/// <reference path="js/site.js" />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
     typescript = require('gulp-typescript'),
    sourcemaps = require('gulp-sourcemaps'),
      tscConfig = require('./tsconfig.json');


var paths = {
    webroot: "./wwwroot/"
};

paths.bootstrapCss = "./node_modules/startbootstrap-sb-admin-2/bower_components/bootstrap/dist/css/bootstrap.css";
paths.sbAdminCss = "./node_modules/startbootstrap-sb-admin-2/dist/css/sb-admin-2.css";
paths.fontAwesomeCss = "./node_modules/startbootstrap-sb-admin-2/bower_components/font-awesome/css/font-awesome.css";
paths.morrisCss = "./node_modules/startbootstrap-sb-admin-2/bower_components/morrisjs/morris.css";
paths.dataTablesbootstrapCss = "./node_modules/startbootstrap-sb-admin-2/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css";
paths.dataTablesresponsiveCss = "./node_modules/startbootstrap-sb-admin-2/bower_components/datatables-responsive/css/dataTables.responsive.css";

paths.jqueryJs = "./node_modules/startbootstrap-sb-admin-2/bower_components/jquery/dist/jquery.js";
paths.raphaelJs = "./node_modules/startbootstrap-sb-admin-2/bower_components/raphael/raphael.js";
paths.morrisJs = "./node_modules/startbootstrap-sb-admin-2/bower_components/morrisjs/morris.js";
paths.bootstrapJs = "./node_modules/startbootstrap-sb-admin-2/bower_components/bootstrap/dist/js/bootstrap.js";
paths.jquerydataTablesJs = "./node_modules/startbootstrap-sb-admin-2/bower_components/datatables/media/js/jquery.dataTables.js";
paths.dataTablesbootstrapJs = "./node_modules/startbootstrap-sb-admin-2/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.js";

paths.fonts = "./node_modules/startbootstrap-sb-admin-2/bower_components/font-awesome/fonts/*";

paths.jsDest = paths.webroot + "lib";
paths.cssDest = paths.webroot + "css";
paths.fontDest = paths.webroot + "css/fonts";

gulp.task("min:js", function () {
    return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs, paths.bootstrapJs, paths.jquerydataTablesJs, paths.dataTablesbootstrapJs])
        .pipe(concat(paths.jsDest + "/min/site.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("copy:js", function () {
    return gulp.src([paths.jqueryJs, paths.raphaelJs, paths.morrisJs, paths.bootstrapJs, paths.jquerydataTablesJs, paths.dataTablesbootstrapJs])
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task("min:css", function () {
    return gulp.src([paths.bootstrapCss, paths.sbAdminCss, paths.fontAwesomeCss, paths.morrisCss, paths.dataTablesbootstrapCss, paths.dataTablesresponsiveCss])
        .pipe(concat(paths.cssDest + "/min/site.min.css"))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("copy:css", function () {
    return gulp.src([paths.bootstrapCss, paths.sbAdminCss, paths.fontAwesomeCss, paths.morrisCss, paths.dataTablesbootstrapCss, paths.dataTablesresponsiveCss])
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task("copy:fonts", function () {
    return gulp.src([paths.fonts])
        .pipe(gulp.dest(paths.fontDest));
});


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
          "js/app.component.js",
          "js/customer/ICustomer.js"
      ])
      .pipe(gulp.dest('wwwroot/js'));
});


gulp.task('default', ['copylibs', 'typescript']);
gulp.task("min", ["min:js", "min:css"]);
gulp.task("copy", ["copy:js", "copy:css", "copy:fonts"]);
