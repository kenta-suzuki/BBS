<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class BBSModel extends Model
{
	protected $table = 'bbs_tabale';
    public function getAllPostingData()
    {
    	$all_data = BBSModel::query()
    		->orderBy('created_at','asc')
    		->get();
    	return $all_data;
    }

    public function getDataFromId(int $id)
    {
    	$datas = BBSModel::query()
    		->where('id', $id)
    		->get();
    	return $datas;
    }
}
