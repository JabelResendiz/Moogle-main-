
// esta es una clase matematica que implementa varios metodos de calculo
namespace MoogleEngine{
    
    public class AplicatedMath{
        
        // calculo de tfidf
        //cantWordsDocuments es la cantidad de veces en los que aparece la palabra dentro del doc
        //cantWords es la cantidad de palabras de del documento
        //countDoc es la cantidad de documentos
        // countDocWord es el numero de docuemntos en los que aparece la palabra
        public double TFIDF(double cantWordsDocuments,double cantWords,double countDoc ,double countDocWord){

            double tf= (cantWordsDocuments/cantWords);// se refiere a la frecuencia de termino 
            
            double idf =(tf==0)?0: Math.Log10(countDoc/(countDocWord-0.5));
            
            return tf*idf;
            
        }
        // multiplicacion de un vector por otro vector mult(A,B)=Σ(Ai*Bi)
        private double VectorMult(Dictionary<string,double>Query,Dictionary<string,double>WordScore){
            
            double mult=0;
            foreach(var s in Query){
                mult+=s.Value*WordScore[s.Key];
            }
            return mult;
        }
        // calculo de la FunCos de dos vectores 
        // responde a la formula s(A,B)= Σ(Ai*Bi)/(√(Σ Ai^2)*√(Σ Bi^2)+1) para dos vectores A y B y sus indices sus elementos
        public double FunCos(Dictionary<string,double>Query,Dictionary<string,double>WordScore){
            double moduloVectorQuery= new double();
            double moduloVectorScore=new double();
            NormVector(Query,ref moduloVectorQuery);
            NormVector(WordScore,ref moduloVectorScore);
            double sim=VectorMult(Query,WordScore )/(Math.Sqrt(moduloVectorQuery*moduloVectorScore)+1);
            return sim;
        }
        
        // normalizacion de un vector numerico es la operacio mediante la cual el vector es convertido a la longitud 1
        // responde a la formula √(Σ Xi^2) con Xi los elementos del vector
        // declaro moduloVector por referencia xq hace falta para calcular la similitud
        public void NormVector(Dictionary<string,double>vector, ref double moduloVector){
            
            double sumSquare=0;
            foreach(var s in vector){
                 sumSquare+= Math.Pow(s.Value,2);
            }
            moduloVector=Math.Sqrt(sumSquare);
            foreach(var s in vector){
                vector[s.Key]=s.Value/moduloVector;
            }
                
        }
        
    }
}