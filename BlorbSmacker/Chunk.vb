Public Class Chunk
    Public indexnumber As Integer 'if we can match up the starting address of this chunk, with an address in the index list, populate this index number here
    Public chunkname(3) As Byte
    Public chunksize(3) As Byte
    Public chunkdata() As Byte
End Class
