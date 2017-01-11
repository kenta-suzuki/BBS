<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Http\Response;
use App\BBSModel;

class BBSController extends Controller
{
	public function __construct()
	{
		$model = new BBSModel();
	}

    public function getIndex()
    {
    	$model = new BBSModel;
    	$val = $model->getAllPostingData();
    	return $val;
    }

    public function getPostingThread()
    {

    }
}
