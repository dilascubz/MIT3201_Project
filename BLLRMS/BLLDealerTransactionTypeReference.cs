using System.Data;
using DALMPRS;

namespace BLLMPRS
{
    public  class BLLDealerTransactionTypeReference
    {
        private DALDealerTransactionTypeReference objdalDealerTransactionTypeReferenceDAL;

        public BLLDealerTransactionTypeReference()
        {
            objdalDealerTransactionTypeReferenceDAL = new DALDealerTransactionTypeReference();
        }

        public DataSet SelectAllDealerTransactionType()
        {
            return objdalDealerTransactionTypeReferenceDAL.SelectAllDealerTransactionType();
        }

        public int UpdateDealerTransactionType(string strId, string strDescription, char chrType, bool bitStatus)
        {
            return objdalDealerTransactionTypeReferenceDAL.UpdateDealerTransactionType(strId, strDescription, chrType, bitStatus);
        }

        public int InsertDealerTransactionType(string strDescription, char chrType, bool bitStatus, string strUserId)
        {
            return objdalDealerTransactionTypeReferenceDAL.InsertDealerTransactionType(strDescription, chrType, bitStatus, strUserId);
        }

        public int DeleteDealerTransactionType(string strID)
        {
            return objdalDealerTransactionTypeReferenceDAL.DeleteDealerTransactionType(strID);
        }

        // Public Function SelectRearingDiscountMiscTransactionByCode(ByVal strId As String) As Double
        // Dim dsMiscTransactionType As DataSet

        // dsMiscTransactionType = DataAccess.GetDataSet("SELECT NetTransportFee from DealerTransactionDetail WHERE ID='" & strId & "'")

        // If dsMiscTransactionType.Tables(0).Rows.Count > 0 Then
        // Return dsMiscTransactionType.Tables(0).Rows(0).Item("NetTransportFee")
        // End If
        // End Function

        // Public Function GetExistingAdditionsById(ByVal strId As String) As Double
        // Dim dsDealerTransType As DataSet
        // Dim SelectCommand As String
        // SelectCommand = "SELECT SUM(RearingDiscountMiscTransaction.Amount) AS Amount" & _
        // " FROM       DealerTransType INNER JOIN " & _
        // "           RearingDiscountMiscTransaction ON DealerTransType.Id = RearingDiscountMiscTransaction.DealerMiscTransTypeId " & _
        // " WHERE      (DealerTransType.Type = 'A' AND DealerTransType.Id='" & strId & "' )"

        // dsDealerTransType = DataAccess.GetDataset(SelectCommand)

        // If dsDealerTransType.Tables(0).Rows.Count > 0 Then
        // If IsDBNull(dsDealerTransType.Tables(0).Rows(0).Item("Amount")) Then
        // Return 0
        // Else
        // Return dsDealerTransType.Tables(0).Rows(0).Item("Amount")
        // End If

        // Else
        // Return 0
        // End If
        // End Function

        // Public Function GetExistingDeductionsById(ByVal strId As String) As Double
        // Dim dsDealerTransType As DataSet
        // Dim SelectCommand As String
        // SelectCommand = "SELECT SUM(RearingDiscountMiscTransaction.Amount) AS Amount" & _
        // " FROM       DealerTransType INNER JOIN " & _
        // "           RearingDiscountMiscTransaction ON DealerTransType.Id = RearingDiscountMiscTransaction.DealerMiscTransTypeId " & _
        // " WHERE      (DealerTransType.Type = 'D' AND DealerTransType.Id='" & strId & "' )"

        // dsDealerTransType = DataAccess.GetDataset(SelectCommand)

        // If dsDealerTransType.Tables(0).Rows.Count > 0 Then
        // If IsDBNull(dsDealerTransType.Tables(0).Rows(0).Item("Amount")) Then
        // Return 0
        // Else
        // Return dsDealerTransType.Tables(0).Rows(0).Item("Amount")
        // End If

        // Else
        // Return 0
        // End If
        // End Function
    }
}