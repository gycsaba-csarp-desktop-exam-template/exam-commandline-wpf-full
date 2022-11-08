<template> 
    <div class="card mt-2">   
        <div class="card-header">
                <h4>Új tantárgy felvétele</h4>
            </div> 
        <div class="card-body">
            <div class="card-title text-left"></div>
            <form class="form-inline" v-on:submit.prevent="onSubmit">
                <!--
                <div class="form-group">
                    <label>Azon.:</label>
                    <input  type="text" class="form-control ml-sm-2 mr-sm-4 my-2"  required/>
                </div>
                -->
                <div class="form-group">
                    <label>Tantárgy név:</label>
                    <input  type="text" class="form-control ml-sm-2 mr-sm-4 my-2"  required/>
                </div>
                <div class="form-group">
                    <div class="ml-auto text-right">
                        <button class="form-control ml-sm-2 mr-sm-4 my-2" type="submit">Mentés</button>
                    </div>
                </div>
            </form>
        </div>
        <div class="card mt-2">
            <div class="card-header">
                <h4>Tantárgyak listája</h4>
            </div>
            <div class="card-body">
                <div class="card-title text-left">A tantárgy adatait szerkeszheti vagy törölheti.</div>
            </div>
            <div class="container text-left">
                <div class="row">
                    <div class="col-sm">Azon.</div>
                    <div class="col-sm">Tantárgy név</div>
                    <div class="col-sm">Műveletek</div>
                </div>
                <div v-for="(subjct,index) in subjects"
                                :key="index"
                                class="row">
                    <div class="col-sm">a</div>
                    <div class="col-sm">b</div>
                    <b-col class="m-sm-1">
                        <b-icon icon="pencil" class="p-3"></b-icon>
                        <b-icon icon="trash" class="p-3"></b-icon>
                    </b-col>                      
                </div>
            </div>
        </div>
    </div> 
</template>

<script>

import SubjectService from "@/services/SubjectService.js";

export default {
    name: 'SubjectList',

    data() {
        return {
            subjects:[]
        }
    },
    mathods:{ 
        retriveSubjects() {
            SubjectService.getAllSubjects()
                .then(response => {
                    this.subjects = response.data;
                    console.log(response.data)
                })
                .catch(e => {
                    console.log(e);
                })      

        },              
        
        beforeCreate() {
            console.log("Tantárgyak megjelenítése.");
            this.retriveSubjects();
        },

        mounted() {
            console.log("Tantárgyak mountolás.");
           this.retriveSubjects();
        },
    }
}

</script>
