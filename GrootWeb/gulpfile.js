var gulp = require('gulp'),
    gp_concat = require('gulp-concat'),
    gp_uglify = require('gulp-uglify'),
    gp_rename = require('gulp-rename'),
    gp_min = require('gulp-min'),
    gp_annotate = require('gulp-ng-annotate'),
    gp_sass = require('gulp-sass'),
    inject = require('gulp-inject'),
    clean = require('gulp-clean')
    watch = require('gulp-watch');

var paths = {
  static: ["node_modules/angular/angular.min.js", "node_modules/angular-route/angular-route.min.js", "node_modules/angular-cookies/angular-cookies.min.js"],
  scripts: ["App/components/appconfig/appconfig.js", "App/components/controllers/*.js", "App/components/directives/*.js", "App/components/factories/*.js"],
  styles: "App/scss/*.scss",
  buildStyles: "App/css/*.css",
  build: ["App/build/static.js", "App/build/app.min.js", "App/build/app.css"]
};

gulp.task('watch', function () {
  gulp.watch(paths.styles, ['styles']);
});

gulp.task('clean', function(){
  gulp.src('App/build', {read:false})
    .pipe(clean());
});

/*BUILD TASKS*/
gulp.task('buildScripts', function(){
  return gulp.src(paths.scripts)
    .pipe(gp_concat('app.min.js'))
    .pipe(gp_annotate())
    .pipe(gp_uglify())
    .pipe(gp_min())
    .pipe(gulp.dest('App/build'))
});

gulp.task('buildStyles', function(){
    return gulp.src(paths.buildStyles)
        .pipe(gp_concat('app.css'))
        .pipe(gp_min())
        .pipe(gulp.dest('App/build'))
});

gulp.task('build', ['buildScripts', 'buildStyles']);

gulp.task('injectBuild', function(){
  gulp.src('./index.html')
  .pipe(inject(gulp.src(paths.build), {relative: true}))
  .pipe(gulp.dest('./'));
});

/*END BUILD TASKS*/

gulp.task('styles', function(){
  gulp.src(paths.styles)
    .pipe(gp_sass())
    .pipe(gulp.dest("App/css"));
});

gulp.task('inject', function(){
  gulp.src('./index.html')
  .pipe(inject(gulp.src(paths.static.concat(paths.scripts).concat(paths.buildStyles)), {relative: true}))
  .pipe(gulp.dest('./'));
});
