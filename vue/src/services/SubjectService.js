import http from "../http-commons";

class SubjectService {
    getAll() {
        return http.get("/Subject/api/subjects");
    }
}