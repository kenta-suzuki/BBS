<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Test;

class bbs_test extends Controller
{
    public function Index()
    {
        /*
    	Request $request = new Request;
    	$request
    	$this -> CreateTable('test', 'testes', 'email', 'pass', 'file', 0, false);
        */

        $val = Test::query()->where('id', '<>', 1)->get();
        dd($val);
    }

    public function UpdateText()
    {
        $updateText = 'updateText';
        Test::query()->where('id', 1)->update(['text' => $updateText]);
    }

    public function DeletePosting()
    {
        Test::query()->where('id', 1)->delete();
    }

    public function CreatePostingData()
    {
        $this -> CreateTable('test', 'testes', 'email', 'pass', 'file', 0, false);
    }

    private function CreateTable(string $subject, string $text, string $email, string $pass, string $file_name, int $parent_id, bool $is_deleted)
    {
    	Test::unguard();
    	Test::firstOrCreate([
    		'subject' => $subject,
    		'text' => $text,
    		'email' => $email,
    		'password' => $pass,
    		'file_name' => $file_name,
    		'parent_bbs_id' => $parent_id,
    		'is_deleted' => $is_deleted,
    		]);
    }
}
