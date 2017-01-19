<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| This file is where you may define all of the routes that are handled
| by your application. Just tell Laravel the URIs it should respond
| to using a Closure or controller method. Build something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Route::get('/test', 'bbs_test@Index');
Route::get('/create', 'bbs_test@CreatePostingData');
Route::get('/update', 'bbs_test@UpdateText');
Route::get('/delete', 'bbs_test@DeletePosting');


Route::get('/bbs/', 'BBSController@getAllArticle');
Route::get('create/{request}/', 'BBSController@createArticle');

