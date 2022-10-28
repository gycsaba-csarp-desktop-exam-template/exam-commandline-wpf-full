import http from "../http-commons";

class SubjectService {
    getAllSubjects() {
        return http.get("/Subject/api/subjects");
    }
}

export default new SubjectService();