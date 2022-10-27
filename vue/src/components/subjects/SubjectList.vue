<template>
    <div class="card">    
        <div class="card-header">
            <h4>Új tantárgy megadása</h4>
            <div class="card-body">
                <form class="form-inline" v-on:submit.prevent="onSubmit">
                    <div class="form-group">
                        <label>Azon.</label>
                        <input  type="text" class="form-control ml-sm-2 mr-sm-4 my-2"  required/>
                    </div>
                    <div class="form-group">
                        <label>Tantárgy név</label>
                        <input  type="text" class="form-control ml-sm-2 mr-sm-4 my-2"  required/>
                    </div>
                    <div class="form-group">
                        <div class="ml-auto text-right">
                            <button class="form-control ml-sm-2 mr-sm-4 my-2" type="submit">Mentés</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
  
</template>

<script>
export default {
    name: 'SubjectList'
}
</script>
