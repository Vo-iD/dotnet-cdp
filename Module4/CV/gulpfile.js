var gulp = require('gulp');
var less = require('gulp-less');
var watch = require('gulp-watch');

gulp.task('watch', function() {
    return watch('less/*.less', function() {
        gulp.src('less/styles.less')
            .pipe(less())
            .pipe(gulp.dest('css'));
    });
});

gulp.task('less', function () {
    return gulp.src(['less/**/*.less'])
        .pipe(less())
        .pipe(gulp.dest('css'));
});