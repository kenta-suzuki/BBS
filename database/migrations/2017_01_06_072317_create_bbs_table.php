<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateBbsTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('bbs_tabale', function (Blueprint $table) {
            $table->increments('id');
            $table->string('subject');
            $table->string('text');
            $table->string('email');
            $table->string('password');
            $table->string('file_name');
            $table->string('parent_bbs_id');
            $table->bool('is_deleted');
            $table->rememberToken();
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::drop('users');
    }
}
