import http from "../http-commons";

class SubjectService {
    getAllSubjects() {
        return http.get("/api/subject");
    }
}

export default new SubjectService();